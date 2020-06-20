using Context;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class PedidoBL
    {
        private ApiContext _context;

        public PedidoBL(ApiContext context)
        {
            _context = context;
        }

        public List<Pedido> getPedidosVendaUsuario(int IdUsuario)
        {
            List<Pedido> pedList = new List<Pedido>();

            if (IdUsuario != 0)
            {
                pedList = _context.Pedido.Select(x => x).Where(p => p.Tipo == "Venda" && p.IdUsuario == IdUsuario).Include(p => p.Detalhepedido).Include(p => p.Movimentacao).ToList();

            }
            return pedList;
        }
        public Pedido getPedidoVenda(int id)
        {
            Pedido pedido = new Pedido();

            if(id != 0)
            {
                pedido = _context.Pedido.Select(x => x).Where(p => p.Tipo == "Venda" && p.IdPedido == id).Include(p => p.Movimentacao).FirstOrDefault();
                var detalhes = _context.Detalhepedido.Select(d => d).Where(d => d.IdPedido == id).Include(d => d.IdProdutoNavigation).ToList();
                pedido.Detalhepedido = detalhes;

            }
            return pedido;
        }
        public Pedido getPedidoUltimo()
        {
            Pedido ped = new Pedido();

            ped = _context.Pedido.Select(x => x).OrderByDescending(p => p.Data).FirstOrDefault();

            return ped;
        }
    }
}
