using Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class ProdutoBL
    {

        private ApiContext _context;

        public ProdutoBL(ApiContext context)
        {
            _context = context;
        }
        public List<Cadastroproduto> getProdutos()
        {
            List<Cadastroproduto> prodList = new List<Cadastroproduto>();
            try
            {
                prodList = _context.Cadastroproduto.Select(x => x).Include(e => e.Estoque).ToList();
                foreach (Cadastroproduto produto in prodList)
                {
                    var estoque = produto.Estoque.OrderByDescending(e => e.Data).FirstOrDefault();
                    if (estoque.EstoqueAtual >= estoque.EstoqueMin)
                    {
                        produto.valEstoque = 1;
                    }
                    else
                    {
                        produto.valEstoque = 0;
                    }
                }
                
            }
            catch(Exception)
            {

            }
            return prodList;

        }
        public Cadastroproduto getProduto(int id)
        {
            Cadastroproduto produto = new Cadastroproduto();

            produto = _context.Cadastroproduto.Select(p => p).Where(x => x.IdProduto == id).Include(e => e.Estoque).FirstOrDefault();

            var estoque = produto.Estoque.OrderByDescending(e => e.Data).FirstOrDefault();
            if (estoque.EstoqueAtual >= estoque.EstoqueMin)
            {
                produto.valEstoque = 1;
            }
            else
            {
                produto.valEstoque = 0;
            }

            return produto;
        }
        public List<Cadastroproduto> getProdutoCategoria(string categoria)
        {
            List<Cadastroproduto> prodList = new List<Cadastroproduto>();

            prodList = _context.Cadastroproduto.Select(p => p).Where(x => x.Categoria == categoria).ToList();

            return prodList;
        }
        public void updateProduto(int id, Cadastroproduto produto)
        {
        }
        public bool insertProduto(Cadastroproduto produto)
        {
            try
            {

                _context.Add(produto);
                _context.SaveChanges();

                return true;

            }
            catch(Exception)
            {
                return false;
            }
        }
        public void deleteProduto(int id)
        {
        }
    }
}
