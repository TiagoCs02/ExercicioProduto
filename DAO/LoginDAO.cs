using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using Models;

namespace DAO
{
    public class LoginDAO
    {
        string connectionString = "Server=localhost;Port=5432;Database=projeto;User Id=postgres;Password=postgresql;";
        public bool verificaLogin(Usuario usuario)
        {
            bool retorno = false;
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                string comandoSQL = "Select * from cadastrousuario";
                NpgsqlCommand comando = new NpgsqlCommand(comandoSQL, con);
                comando.CommandType = CommandType.Text;

                try
                {
                    List<Usuario> usuarios = new List<Usuario>();

                    con.Open();
                    NpgsqlDataReader rdr = comando.ExecuteReader();

                    while (rdr.Read())
                    {
                        Usuario login = new Usuario();

                        login.email = rdr["email"].ToString();
                        login.senha = rdr["senha"].ToString();

                        usuarios.Add(login);
                    }
                    foreach (Usuario login in usuarios)
                    {
                        if(login.email == usuario.email && login.senha == usuario.senha)
                        {
                            retorno = true;
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return retorno;
        }
    }
}
