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
    public class UsuarioController : ControllerBase
    {
        // GET: api/Usuario
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            UsuarioBL userBl = new UsuarioBL();
            List<Usuario> usuarioList = userBl.getUsuarios();
            return usuarioList;
        }

        // GET: api/Usuario/5
        [HttpGet("{id}", Name = "Get")]
        public Usuario Get(int id)
        {
            UsuarioBL userBl = new UsuarioBL();
            Usuario usuario = userBl.getUsuario(id);
            return usuario;
        }

        // POST: api/Usuario
        [HttpPost]
        public string Post([FromForm] Usuario usuario)
        {
            UsuarioBL userBl = new UsuarioBL();
            if (userBl.insertUsuario(usuario))
            {
                return "Usuario cadastrado";
            }
            return "Falha ao cadastrar usuario"; 
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Usuario usuario)
        {
            UsuarioBL userBl = new UsuarioBL();
            if (userBl.updateUsuario(id,usuario))
            {
                return "Usuario atualizado";
            }
            return "Falha ao atualizar usuario";
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            UsuarioBL userBl = new UsuarioBL();
            if (userBl.deleteUsuario(id))
            {
                return "Usuario deletado";
            }
            return "Falha ao deletar usuario";
        }
    }
}
