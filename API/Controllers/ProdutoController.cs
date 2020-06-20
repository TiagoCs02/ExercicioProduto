using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private ApiContext _context;
        public ProdutoController(ApiContext context)
        {
            _context = context;
        }
        // GET: api/Produto
        [HttpGet]
        public IEnumerable<Cadastroproduto> Get()
        {
            ProdutoBL prodBl = new ProdutoBL(_context);
            return prodBl.getProdutos();
        }
        [HttpGet("categoria/{categoria}")]
        public IEnumerable<Cadastroproduto> GetPorCategoria(string categoria)
        {
            ProdutoBL prodBl = new ProdutoBL(_context);
            return prodBl.getProdutoCategoria(categoria);
        }

        // GET: api/Produto/5
        [HttpGet("{id}")]
        public Cadastroproduto Get(int id)
        {
            ProdutoBL prodBl = new ProdutoBL(_context);
            Cadastroproduto produto = prodBl.getProduto(id);
            return produto;
        }
        [HttpGet("pesquisa")]
        public List<Cadastroproduto> getPesquisa()
        {
            ProdutoBL prodBl = new ProdutoBL(_context);
            return prodBl.getProdutos();
        }
        [HttpGet("pesquisa/{pesquisa}")]
        public List<Cadastroproduto> getPesquisa(string pesquisa)
        {
            ProdutoBL prodBl = new ProdutoBL(_context);
            return prodBl.getPesquisa(pesquisa);
        }

        // POST: api/Produto
        [HttpPost]
        public bool Post([FromForm] Cadastroproduto produto)
        {
            ProdutoBL prodBl = new ProdutoBL(_context);
            return prodBl.insertProduto(produto);
        }
        // PUT: api/Produto/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cadastroproduto produto)
        {
            ProdutoBL prodBl = new ProdutoBL(_context);
            //return prodBl.updateProduto(id,produto);
        }

        // DELETE: api/Produto/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ProdutoBL prodBl = new ProdutoBL(_context);
           // return prodBl.deleteProduto(id);
        }
    }
}
