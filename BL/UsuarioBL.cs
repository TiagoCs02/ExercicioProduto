using Context;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public class UsuarioBL
    {

        private ApiContext _context;

        public UsuarioBL(ApiContext context)
        {
            _context = context;
        }

        public List<Cadastrousuario> getUsuarios()
        {
            List<Cadastrousuario> userList = new List<Cadastrousuario>();

            userList = _context.Cadastrousuario.Select(x => x).ToList();

            foreach(Cadastrousuario usuario in userList)
            {
                usuario.Senha = "******";
            }

            return userList;
        }
        public Cadastrousuario getUsuario(int id)
        {
            Cadastrousuario usuario = new Cadastrousuario();

            usuario = _context.Cadastrousuario.Select(u => u).Where(x => x.IdUsuario == id).FirstOrDefault();

            usuario.Senha = "";

            return usuario;
        }
       // public bool updateUsuario(int id, Cadastrousuario usuario)
       // {
       //     userDAO = new UsuarioDAO();
      //      return userDAO.updateUsuario(id, usuario);
       // }
        public int insertUsuario(Cadastrousuario usuario)
        {
            Cadastrousuario valUser = new Cadastrousuario();
            try
            {
                valUser = _context.Cadastrousuario.Select(x => x).Where(u => u.Email == usuario.Email).FirstOrDefault();

                if (valUser != null)
                {
                    return 0;//Usuario já cadastrado
                }

                _context.Add(usuario);
                _context.SaveChanges();

                return 1;//Cadastro com sucesso
            }
            catch(Exception)
            {
                return 2;//Erro de exception
            }
        }
        public void deleteUsuario(int id)
        {
        }
    }
}
