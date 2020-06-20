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
    public class PedidoController : ControllerBase
    {
        private ApiContext _context;

        public PedidoController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Pedido
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Pedido/5
        [HttpGet("venda/{id}")]
        public List<Pedido> GetPedidosVendaUsuario(int id)
        {
            PedidoBL pedBl = new PedidoBL(_context);
            return pedBl.getPedidosVendaUsuario(id);
        }
        [HttpGet("detalhes/{id}")]
        public Pedido GetPedidoVenda(int id)
        {
            PedidoBL pedBl = new PedidoBL(_context);
            return pedBl.getPedidoVenda(id);
        }

        // POST: api/Pedido
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Pedido/5
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
