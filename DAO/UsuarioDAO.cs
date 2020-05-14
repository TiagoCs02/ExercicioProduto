using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Npgsql;
using System.Data;
using API.Models;

namespace DAO
{
    public class UsuarioDAO
    {
        string connectionString = "Server=localhost;Port=5432;Database=projeto;User Id=postgres;Password=postgresql;";
        public List<Cadastrousuario> getUsuarios()
        {
            List<Cadastrousuario> usuarioList = new List<Cadastrousuario>();
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
                        Cadastrousuario usuario = new Cadastrousuario();
                        usuario.Idusuario = (int)rdr["idUsuario"];
                        usuario.Email = rdr["email"].ToString();
                        usuario.Senha = rdr["senha"].ToString();
                        usuario.Nome = rdr["nome"].ToString();
                        usuario.Sobrenome = rdr["sobrenome"].ToString();
                        usuario.Sexo = rdr["sexo"].ToString();
                        usuario.Cpf = rdr["cpf"].ToString();
                        usuario.Telefone = rdr["telefone"].ToString();
                        usuario.Celular = rdr["celular"].ToString();
                        usuario.Cep = rdr["cep"].ToString();
                        usuario.Datanasc = rdr["datanasc"].ToString();
                        usuario.Uf = rdr["uf"].ToString();
                        usuario.Logradouro = rdr["logradouro"].ToString();
                        usuario.Numero = rdr["numero"].ToString();
                        usuario.Cidade = rdr["cidade"].ToString();
                        usuario.Complemento = rdr["complemento"].ToString();
                        usuario.Tipo = (int)rdr["tipo"];

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
        public Cadastrousuario getUsuario(int id)
        {
            Cadastrousuario usuario = new Cadastrousuario();
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                string comandoSQL = "Select * from CadastroUsuario where idusuario = @id";
                NpgsqlCommand comando = new NpgsqlCommand(comandoSQL, con);
                comando.CommandType = CommandType.Text;

                comando.Parameters.AddWithValue("@id", id);

                try
                {
                    con.Open();
                    NpgsqlDataReader rdr = comando.ExecuteReader();

                    while (rdr.Read())
                    {
                        usuario.Idusuario = (int)rdr["idUsuario"];
                        usuario.Email = rdr["email"].ToString();
                        usuario.Nome = rdr["nome"].ToString();
                        usuario.Sobrenome = rdr["sobrenome"].ToString();
                        usuario.Sexo = rdr["sexo"].ToString();
                        usuario.Cpf = rdr["cpf"].ToString();
                        usuario.Telefone = rdr["telefone"].ToString();
                        usuario.Celular = rdr["celular"].ToString();
                        usuario.Cep = rdr["cep"].ToString();
                        usuario.Datanasc = rdr["datanasc"].ToString();
                        usuario.Uf = rdr["uf"].ToString();
                        usuario.Logradouro = rdr["logradouro"].ToString();
                        usuario.Numero = rdr["numero"].ToString();
                        usuario.Cidade = rdr["cidade"].ToString();
                        usuario.Complemento = rdr["complemento"].ToString();
                        usuario.Tipo = (int)rdr["tipo"];
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
            return usuario;
        }
        public bool updateUsuario(int id, Cadastrousuario usuario)
        {
            bool retorno = false;
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                StringBuilder comandoSQL = new StringBuilder();
                comandoSQL.Append("Update cadastrousuario set email = @email, nome = @nome, sobrenome = @sobrenome, ");
                comandoSQL.Append("sexo = @sexo, cpf = @cpf, telefone = @telefone, celular = @celular, cep = @cep, ");
                comandoSQL.Append("datanasc = @datanasc, uf = @uf, logradouro = @logradouro, numero = @numero, ");
                comandoSQL.Append("cidade = @cidade, complemento = @complemento, tipo = @tipo where idUsuario = @id");
                NpgsqlCommand comando = new NpgsqlCommand(comandoSQL.ToString(), con);
                comando.CommandType = CommandType.Text;

                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@email", usuario.Email);
                comando.Parameters.AddWithValue("@nome", usuario.Nome);
                comando.Parameters.AddWithValue("@sobrenome", usuario.Sobrenome);
                comando.Parameters.AddWithValue("@sexo", usuario.Sexo);
                comando.Parameters.AddWithValue("@cpf", usuario.Cpf);
                comando.Parameters.AddWithValue("@telefone", usuario.Telefone);
                comando.Parameters.AddWithValue("@celular", usuario.Celular);
                comando.Parameters.AddWithValue("@cep", usuario.Cep);
                comando.Parameters.AddWithValue("@datanasc", usuario.Datanasc);
                comando.Parameters.AddWithValue("@uf", usuario.Uf);
                comando.Parameters.AddWithValue("@logradouro", usuario.Logradouro);
                comando.Parameters.AddWithValue("@numero", usuario.Numero);
                comando.Parameters.AddWithValue("@cidade", usuario.Cidade);
                comando.Parameters.AddWithValue("@complemento", usuario.Complemento);
                comando.Parameters.AddWithValue("@tipo", usuario.Tipo);

                try
                {
                    con.Open();
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    retorno = true;
                }
            }
            return retorno;
        }
        public bool insertUsuario(Cadastrousuario usuario)
        {
            bool retorno = false;
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                StringBuilder comandoSQL = new StringBuilder();
                comandoSQL.Append("Insert into CadastroUsuario(idUsuario, email, senha, nome, sobrenome, sexo, ");
                comandoSQL.Append("cpf, telefone, celular, cep, datanasc, uf, logradouro, numero, cidade, complemento) ");
                comandoSQL.Append("values(@email, @senha, @nome, @sobrenome, @sexo, @cpf, @telefone, @celular, @cep, ");
                comandoSQL.Append("@datanasc, @uf, @logradouro, @numero, @cidade, @complemento, @tipo)");
                NpgsqlCommand comando = new NpgsqlCommand(comandoSQL.ToString(), con);
                comando.CommandType = CommandType.Text;

                comando.Parameters.AddWithValue("@email", usuario.Email);
                comando.Parameters.AddWithValue("@senha", usuario.Senha);
                comando.Parameters.AddWithValue("@nome", usuario.Nome);
                comando.Parameters.AddWithValue("@sobrenome", usuario.Sobrenome);
                comando.Parameters.AddWithValue("@sexo", usuario.Sexo);
                comando.Parameters.AddWithValue("@cpf", usuario.Cpf);
                comando.Parameters.AddWithValue("@telefone", usuario.Telefone);
                comando.Parameters.AddWithValue("@celular", usuario.Celular);
                comando.Parameters.AddWithValue("@cep", usuario.Cep);
                comando.Parameters.AddWithValue("@datanasc", usuario.Datanasc);
                comando.Parameters.AddWithValue("@uf", usuario.Uf);
                comando.Parameters.AddWithValue("@logradouro", usuario.Logradouro);
                comando.Parameters.AddWithValue("@numero", usuario.Numero);
                comando.Parameters.AddWithValue("@cidade", usuario.Cidade);
                comando.Parameters.AddWithValue("@complemento", usuario.Complemento);
                comando.Parameters.AddWithValue("@tipo", usuario.Tipo);

                try
                {
                    con.Open();
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    retorno = true;
                }
            }
            return retorno;
        }
        public bool deleteUsuario(int id)
        {
            bool retorno = false;
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                string comandoSQL = "Delete from cadastrousuario where idusuario = @id";
                NpgsqlCommand comando = new NpgsqlCommand(comandoSQL, con);
                comando.CommandType = CommandType.Text;

                comando.Parameters.AddWithValue("@id", id);

                try
                {
                    con.Open();
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                    retorno = true;
                }
            }
            return retorno;
        }
    }
}
