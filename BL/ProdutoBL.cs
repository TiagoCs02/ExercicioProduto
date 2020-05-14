using API.Models;
using Context;
using DAO;
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
            prodList = _context.Cadastroproduto.Select(x => x).ToList();
            return prodList;

            //prodDAO = new ProdutoDAO();
            //return prodDAO.getProdutos().OrderByDescending(p => p.Nome);
        }
        public Cadastroproduto getProduto(int id)
        {
            prodDAO = new ProdutoDAO();
            return prodDAO.getProduto(id);
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
