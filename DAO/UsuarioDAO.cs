using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Npgsql;
using System.Data;

namespace DAO
{
    public class UsuarioDAO
    {
        string connectionString = "Server=localhost;Port=5432;Database=projeto;User Id=postgres;Password=postgresql;";
        public List<Usuario> getUsuarios()
        {
            List<Usuario> usuarioList = new List<Usuario>();
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                string comandoSQL = "Select * from CadastroUsuario";
                NpgsqlCommand comando = new NpgsqlCommand(comandoSQL, con);
                comando.CommandType = CommandType.Text;

                try
                {
                    con.Open();
                    NpgsqlDataReader rdr = comando.ExecuteReader();

                    while (rdr.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.IdUsuario = (int)rdr["idUsuario"];
                        usuario.nome = rdr["nome"].ToString();

                        usuarioList.Add(usuario);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return usuarioList;
        }
    }
}
