using Context;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class CompraBL
    {
        private ApiContext _context;
        public CompraBL(ApiContext context)
        {
            _context = context;
        }

        public int insertCompra(Pedido ped, List<Cadastroproduto> prodList)
        {
            if(ped == null)
            {
                return 0;
            }
            _context.Add<Pedido>(ped);
            _context.SaveChanges();
            Pedido pedido = _context.Pedido.Select(x => x).OrderByDescending(p => p.Data).FirstOrDefault();
            var nf = 1;
            Movimentacao movimentacao = _context.Movimentacao.Select(x => x).Where(m => m.Tipo == "Saida").OrderByDescending(y => y.IdMovimentacao).FirstOrDefault();
            if (movimentacao != null)
            {
                nf = Int32.Parse(movimentacao.Nf) + 1;
            }
            foreach (Cadastroproduto produto in prodList)
            {
                Detalhepedido detPed = new Detalhepedido
                {
                    IdPedido = pedido.IdPedido,
                    IdProduto = produto.IdProduto,
                    Quantidade = produto.Quantidade
                };
                _context.Add(detPed);

                Estoque est = _context.Estoque.Select(x => x).Where(e => e.IdProduto == produto.IdProduto).OrderByDescending(y => y.Data).FirstOrDefault();

                est.EstoqueAtual = est.EstoqueAtual - produto.Quantidade;
                est.Data = DateTime.Now;

                _context.Add<Estoque>(est);
                
                Movimentacao mov = new Movimentacao
                {
                    Data = DateTime.Now,
                    IdPedido = pedido.IdPedido,
                    IdProduto = produto.IdProduto,
                    Quantidade = produto.Quantidade,
                    Tipo = "Saida",
                    Nf = nf.ToString(),
                    DataNf = DateTime.Now
                };

                _context.Add<Movimentacao>(mov);

                _context.SaveChanges();
            }

            return 1;
        }
    }
}
