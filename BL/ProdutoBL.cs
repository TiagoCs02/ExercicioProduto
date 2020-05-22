using API.Models;
using Context;
using DAO;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class ProdutoBL
    {
        ProdutoDAO prodDAO;

        private ApiContext _context;

        public ProdutoBL(ApiContext context)
        {
            _context = context;
        }
        public List<Cadastroproduto> getProdutos()
        {
            List<Cadastroproduto> prodList = new List<Cadastroproduto>();
            prodList = _context.Cadastroproduto.Select(x => x).Include(e => e.Estoque).ToList();
            foreach(Cadastroproduto produto in prodList)
            {
                var estoque = produto.Estoque.OrderByDescending(e => e.Data).FirstOrDefault();
                if (estoque.Estoqueatual >= estoque.Estoquemin)
                {
                    produto.valEstoque = 1;
                }
                else
                {
                    produto.valEstoque = 0;
                }
            }
            return prodList;

        }
        public Cadastroproduto getProduto(int id)
        {
            Cadastroproduto produto = new Cadastroproduto();

            produto = _context.Cadastroproduto.Select(p => p).Where(x => x.Idproduto == id).Include(e => e.Estoque).FirstOrDefault();

            var estoque = produto.Estoque.OrderByDescending(e => e.Data).FirstOrDefault();
            if (estoque.Estoqueatual >= estoque.Estoquemin)
            {
                produto.valEstoque = 1;
            }
            else
            {
                produto.valEstoque = 0;
            }

            return produto;
        }
        public bool updateProduto(int id, Cadastroproduto produto)
        {
            prodDAO = new ProdutoDAO();
            return prodDAO.updateProduto(id,produto);
        }
        public bool insertProduto(Cadastroproduto produto)
        {
            prodDAO = new ProdutoDAO();
            return prodDAO.insertProduto(produto);
        }
        public bool deleteProduto(int id)
        {
            prodDAO = new ProdutoDAO();
            return prodDAO.deleteProduto(id);
        }
    }
}
