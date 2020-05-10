using DAO;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class LoginBL
    {
        LoginDAO loginDAO;
        public int validaLogin(Usuario usuario)
        {
            loginDAO = new LoginDAO();
            return loginDAO.verificaLogin(usuario);
        }
    }
}
