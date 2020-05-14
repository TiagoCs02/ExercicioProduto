using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using Models;
using API.Models;

namespace DAO
{
    public class LoginDAO
    {
        string connectionString = "Server=localhost;Port=5432;Database=projeto;User Id=postgres;Password=postgresql;";
        public int verificaLogin(Cadastrousuario usuario)
        {
            int retorno = 0;
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                string comandoSQL = "Select * from cadastrousuario";
                NpgsqlCommand comando = new NpgsqlCommand(comandoSQL, con);
                comando.CommandType = CommandType.Text;

                try
                {
                    List<Cadastrousuario> usuarios = new List<Cadastrousuario>();

                    con.Open();
                    NpgsqlDataReader rdr = comando.ExecuteReader();

                    while (rdr.Read())
                    {
                        Cadastrousuario login = new Cadastrousuario();

                        login.Email = rdr["email"].ToString();
                        login.Senha = rdr["senha"].ToString();
                        login.Idusuario = (int)rdr["idusuario"];

                        usuarios.Add(login);
                    }
                    foreach (Cadastrousuario login in usuarios)
                    {
                        if(login.Email == usuario.Email && login.Senha == usuario.Senha)
                        {
                            retorno = login.Idusuario;
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
