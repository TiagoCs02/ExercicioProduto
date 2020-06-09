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
    public class UsuarioController : ControllerBase
    {
        private Context.ApiContext _context;

        public UsuarioController(Context.ApiContext context)
        {
            _context = context;
        }
        // GET: api/Usuario
        [HttpGet]
        public IEnumerable<Cadastrousuario> Get()
        {
            UsuarioBL userBl = new UsuarioBL(_context);
            List<Cadastrousuario> usuarioList = userBl.getUsuarios();
            return usuarioList;
        }

        // GET: api/Usuario/5
        [HttpGet("{id}", Name = "Get")]
        public Cadastrousuario Get(int id)
        {
            UsuarioBL userBl = new UsuarioBL(_context);
            Cadastrousuario usuario = userBl.getUsuario(id);
            return usuario;
        }

        // POST: api/Usuario
        [HttpPost]
        public int Post(Cadastrousuario usuario)
        {
            UsuarioBL userBl = new UsuarioBL(_context);
            return userBl.insertUsuario(usuario); 
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Cadastrousuario usuario)
        {
            UsuarioBL userBl = new UsuarioBL(_context);
            //if (userBl.updateUsuario(id,usuario))
            //{
             //   return "Usuario atualizado";
            //}
            return "Falha ao atualizar usuario";
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            UsuarioBL userBl = new UsuarioBL(_context);
            //if (userBl.deleteUsuario(id))
            //{
            //    return "Usuario deletado";
            //}
            return "Falha ao deletar usuario";
        }
    }
}
