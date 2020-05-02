using DAO;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class UsuarioBL
    {
        UsuarioDAO userDAO;

        public List<Usuario> getUsuarios()
        {
            userDAO = new UsuarioDAO();
            return userDAO.getUsuarios();
        }
    }
}
