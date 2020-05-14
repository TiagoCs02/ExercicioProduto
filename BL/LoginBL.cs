using API.Models;
using Context;
using DAO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class LoginBL
    {
        private ApiContext _context;
        public LoginBL(ApiContext context)
        {
            _context = context;
        }
        public int validaLogin(Cadastrousuario usuario)
        {
            int retorno = 0;
            Cadastrousuario user = _context.Cadastrousuario.Where(x => x.Email == usuario.Email && x.Senha == usuario.Senha).SingleOrDefault();
            if (user != null)
            {
                retorno = user.Idusuario;
            }
            return retorno;
        }
    }
}
