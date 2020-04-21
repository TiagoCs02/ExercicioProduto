using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        // GET: api/Produto
        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            ProdutoBL prodBl = new ProdutoBL();
            List<Produto> produtoList = prodBl.getProdutos();
            return produtoList.OrderByDescending(p => p.IdProduto);
        }

        // GET: api/Produto/5
        [HttpGet("{id}")]
        public Produto Get(int id)
        {
            ProdutoBL prodBl = new ProdutoBL();
            Produto produto = prodBl.getProduto(id);
            return produto;
        }

        // POST: api/Produto
        [HttpPost]
        public bool Post([FromForm] Produto produto)
        {
            ProdutoBL prodBl = new ProdutoBL();
            return prodBl.insertProduto(produto);
        }
        // PUT: api/Produto/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Produto produto)
        {
            ProdutoBL prodBl = new ProdutoBL();
            return prodBl.updateProduto(id,produto);
        }

        // DELETE: api/Produto/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            ProdutoBL prodBl = new ProdutoBL();
            return prodBl.deleteProduto(id);
        }
    }
}
