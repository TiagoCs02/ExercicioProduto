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
    public class EstoqueController : ControllerBase
    {
        private ApiContext _context;

        public EstoqueController(ApiContext context)
        {
            _context = context;
        }
        // GET: api/Estoque
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Estoque/5
        [HttpGet("produto/{id}")]
        public Estoque GetEstoqueProduto(int id)
        {
            EstoqueBL estBl = new EstoqueBL(_context);
            return estBl.getEstoqueProduto(id);
        }

        // POST: api/Estoque
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Estoque/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
