using API.Models;
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

        public List<Cadastrousuario> getUsuarios()
        {
            userDAO = new UsuarioDAO();
            return userDAO.getUsuarios();
        }
        public Cadastrousuario getUsuario(int id)
        {
            userDAO = new UsuarioDAO();
            return userDAO.getUsuario(id);
        }
        public bool updateUsuario(int id, Cadastrousuario usuario)
        {
            userDAO = new UsuarioDAO();
            return userDAO.updateUsuario(id, usuario);
        }
        public bool insertUsuario(Cadastrousuario usuario)
        {
            userDAO = new UsuarioDAO();
            return userDAO.insertUsuario(usuario);
        }
        public bool deleteUsuario(int id)
        {
            userDAO = new UsuarioDAO();
            return userDAO.deleteUsuario(id);
        }
    }
}
