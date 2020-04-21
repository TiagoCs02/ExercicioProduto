using DAO;
using Models;
using System;
using System.Collections.Generic;

namespace BL
{
    public class ProdutoBL
    {
        ProdutoDAO prodDAO;
        public List<Produto> getProdutos()
        {
            prodDAO = new ProdutoDAO();
            return prodDAO.getProdutos();
        }
        public Produto getProduto(int id)
        {
            prodDAO = new ProdutoDAO();
            return prodDAO.getProduto(id);
        }
        public bool updateProduto(int id, Produto produto)
        {
            prodDAO = new ProdutoDAO();
            return prodDAO.updateProduto(id,produto);
        }
        public bool insertProduto(Produto produto)
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
