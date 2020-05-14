using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
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
        public IEnumerable<Cadastrousuario> Get()
        {
            UsuarioBL userBl = new UsuarioBL();
            List<Cadastrousuario> usuarioList = userBl.getUsuarios();
            return usuarioList;
        }

        // GET: api/Usuario/5
        [HttpGet("{id}", Name = "Get")]
        public Cadastrousuario Get(int id)
        {
            UsuarioBL userBl = new UsuarioBL();
            Cadastrousuario usuario = userBl.getUsuario(id);
            return usuario;
        }

        // POST: api/Usuario
        [HttpPost]
        public bool Post(Cadastrousuario usuario)
        {
            UsuarioBL userBl = new UsuarioBL();
            return userBl.insertUsuario(usuario); 
        }

        // PUT: api/Usuario/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Cadastrousuario usuario)
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
