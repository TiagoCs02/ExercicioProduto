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
                        usuario.email = rdr["email"].ToString();
                        usuario.senha = rdr["senha"].ToString();
                        usuario.nome = rdr["nome"].ToString();
                        usuario.sobrenome = rdr["sobrenome"].ToString();

                        StringBuilder nomeCompl = new StringBuilder();
                        nomeCompl.Append(usuario.nome);
                        nomeCompl.Append(" ");
                        nomeCompl.Append(usuario.sobrenome);

                        usuario.nomeCompleto = nomeCompl.ToString();
                        usuario.sexo = rdr["sexo"].ToString();
                        usuario.cpf = rdr["cpf"].ToString();
                        usuario.telefone = rdr["telefone"].ToString();
                        usuario.celular = rdr["celular"].ToString();
                        usuario.cep = rdr["cep"].ToString();
                        usuario.datanasc = rdr["datanasc"].ToString();
                        usuario.uf = rdr["uf"].ToString();
                        usuario.logradouro = rdr["logradouro"].ToString();
                        usuario.numero = rdr["numero"].ToString();
                        usuario.cidade = rdr["cidade"].ToString();
                        usuario.complemento = rdr["complemento"].ToString();

                        StringBuilder endereco = new StringBuilder();
                        endereco.Append(usuario.logradouro);
                        endereco.Append(", ");
                        endereco.Append(usuario.numero);
                        endereco.Append(", ");
                        if(usuario.complemento != "")
                        {
                            endereco.Append(usuario.complemento);
                            endereco.Append(", ");
                        }
                        endereco.Append(usuario.cidade);
                        endereco.Append("-");
                        endereco.Append(usuario.uf);

                        usuario.endereco = endereco.ToString();
                        usuario.tipo = (int)rdr["tipo"];

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
        public Usuario getUsuario(int id)
        {
            Usuario usuario = new Usuario();
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
                        usuario.IdUsuario = (int)rdr["idUsuario"];
                        usuario.email = rdr["email"].ToString();
                        usuario.nome = rdr["nome"].ToString();
                        usuario.sobrenome = rdr["sobrenome"].ToString();

                        StringBuilder nomeCompl = new StringBuilder();
                        nomeCompl.Append(usuario.nome);
                        nomeCompl.Append(" ");
                        nomeCompl.Append(usuario.sobrenome);

                        usuario.nomeCompleto = nomeCompl.ToString();
                        usuario.sexo = rdr["sexo"].ToString();
                        usuario.cpf = rdr["cpf"].ToString();
                        usuario.telefone = rdr["telefone"].ToString();
                        usuario.celular = rdr["celular"].ToString();
                        usuario.cep = rdr["cep"].ToString();
                        usuario.datanasc = rdr["datanasc"].ToString();
                        usuario.uf = rdr["uf"].ToString();
                        usuario.logradouro = rdr["logradouro"].ToString();
                        usuario.numero = rdr["numero"].ToString();
                        usuario.cidade = rdr["cidade"].ToString();
                        usuario.complemento = rdr["complemento"].ToString();

                        StringBuilder endereco = new StringBuilder();
                        endereco.Append(usuario.logradouro);
                        endereco.Append(", ");
                        endereco.Append(usuario.numero);
                        endereco.Append(", ");
                        if (usuario.complemento != "")
                        {
                            endereco.Append(usuario.complemento);
                            endereco.Append(", ");
                        }
                        endereco.Append(usuario.cidade);
                        endereco.Append("-");
                        endereco.Append(usuario.uf);

                        usuario.endereco = endereco.ToString();
                       // usuario.tipo = (int)rdr["tipo"];
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
        public bool updateUsuario(int id, Usuario usuario)
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
                comando.Parameters.AddWithValue("@email", usuario.email);
                comando.Parameters.AddWithValue("@nome", usuario.nome);
                comando.Parameters.AddWithValue("@sobrenome", usuario.sobrenome);
                comando.Parameters.AddWithValue("@sexo", usuario.sexo);
                comando.Parameters.AddWithValue("@cpf", usuario.cpf);
                comando.Parameters.AddWithValue("@telefone", usuario.telefone);
                comando.Parameters.AddWithValue("@celular", usuario.celular);
                comando.Parameters.AddWithValue("@cep", usuario.cep);
                comando.Parameters.AddWithValue("@datanasc", usuario.datanasc);
                comando.Parameters.AddWithValue("@uf", usuario.uf);
                comando.Parameters.AddWithValue("@logradouro", usuario.logradouro);
                comando.Parameters.AddWithValue("@numero", usuario.numero);
                comando.Parameters.AddWithValue("@cidade", usuario.cidade);
                comando.Parameters.AddWithValue("@complemento", usuario.complemento);
                comando.Parameters.AddWithValue("@tipo", usuario.tipo);

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
        public bool insertUsuario(Usuario usuario)
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

                comando.Parameters.AddWithValue("@email", usuario.email);
                comando.Parameters.AddWithValue("@senha", usuario.senha);
                comando.Parameters.AddWithValue("@nome", usuario.nome);
                comando.Parameters.AddWithValue("@sobrenome", usuario.sobrenome);
                comando.Parameters.AddWithValue("@sexo", usuario.sexo);
                comando.Parameters.AddWithValue("@cpf", usuario.cpf);
                comando.Parameters.AddWithValue("@telefone", usuario.telefone);
                comando.Parameters.AddWithValue("@celular", usuario.celular);
                comando.Parameters.AddWithValue("@cep", usuario.cep);
                comando.Parameters.AddWithValue("@datanasc", usuario.datanasc);
                comando.Parameters.AddWithValue("@uf", usuario.uf);
                comando.Parameters.AddWithValue("@logradouro", usuario.logradouro);
                comando.Parameters.AddWithValue("@numero", usuario.numero);
                comando.Parameters.AddWithValue("@cidade", usuario.cidade);
                comando.Parameters.AddWithValue("@complemento", usuario.complemento);
                comando.Parameters.AddWithValue("@tipo", usuario.tipo);

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
