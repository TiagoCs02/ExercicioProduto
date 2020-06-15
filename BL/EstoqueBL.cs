using Context;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class EstoqueBL
    {
        private ApiContext _context;
        public EstoqueBL(ApiContext context)
        {
            _context = context;
        }

        public Estoque getEstoqueProduto(int id)
        {
            Estoque estoque = new Estoque();
            estoque = _context.Estoque.Select(x => x).Where(e => e.IdProduto == id).OrderByDescending(y => y.Data).FirstOrDefault();
            return estoque;
        }
    }
}
