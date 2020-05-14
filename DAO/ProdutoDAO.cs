using API.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class ProdutoDAO
    {
        string connectionString = "Server=DESKTOP-IKUEHMR;Database=Projeto;Integrated Security=true;";
        public List<Cadastroproduto> getProdutos()
        {
            List<Cadastroproduto> produtoList = new List<Cadastroproduto>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Select * from Produto";
                SqlCommand comando = new SqlCommand(comandoSQL, con);
                comando.CommandType = CommandType.Text;

                try
                {
                    con.Open();
                    SqlDataReader rdr = comando.ExecuteReader();

                    while (rdr.Read())
                    {
                        Cadastroproduto produto = new Cadastroproduto();

                        produto.Idproduto = (int)rdr["idproduto"];
                        produto.Nome = rdr["nome"].ToString();
                        produto.Artista = rdr["artista"].ToString();
                        produto.Categoria = rdr["categoria"].ToString();
                        produto.Valor = (decimal)rdr["valor"];
                        produto.Estado = rdr["estado"].ToString();

                        produtoList.Add(produto);
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
            return produtoList;
        }
        public Cadastroproduto getProduto(int id)
        {
            Cadastroproduto produto = new Cadastroproduto();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Select * from Produto where idProduto = @id";
                SqlCommand comando = new SqlCommand(comandoSQL, con);
                comando.CommandType = CommandType.Text;

                comando.Parameters.AddWithValue("@id", id);

                try
                {
                    con.Open();
                    SqlDataReader rdr = comando.ExecuteReader();

                    while (rdr.Read())
                    {

                        produto.Idproduto = (int)rdr["idproduto"];
                        produto.Nome = rdr["nome"].ToString();
                        produto.Artista = rdr["artista"].ToString();
                        produto.Categoria = rdr["categoria"].ToString();
                        produto.Valor = (decimal)rdr["valor"];
                        produto.Estado = rdr["estado"].ToString();

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
            return produto;
        }
        public bool updateProduto(int id,Cadastroproduto produto)
        {
            bool retorno = false;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Update Produto set Nome = @nome, Artista = @artista, Categoria = @categoria, Valor = @valor, Estado = @estado where idProduto = @id";
                SqlCommand comando = new SqlCommand(comandoSQL, con);
                comando.CommandType = CommandType.Text;

                comando.Parameters.AddWithValue("@id", id);
                comando.Parameters.AddWithValue("@nome", produto.Nome);
                comando.Parameters.AddWithValue("@artista", produto.Artista);
                comando.Parameters.AddWithValue("@categoria", produto.Categoria);
                comando.Parameters.AddWithValue("@valor", produto.Valor);
                comando.Parameters.AddWithValue("@estado", produto.Estado);

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
        public bool insertProduto(Cadastroproduto produto)
        {
            bool retorno = false;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Insert into Produto values(@nome, @artista,@categoria, @valor, @estado)";
                SqlCommand comando = new SqlCommand(comandoSQL, con);
                comando.CommandType = CommandType.Text;

                comando.Parameters.AddWithValue("@id", produto.Idproduto);
                comando.Parameters.AddWithValue("@nome", produto.Nome);
                comando.Parameters.AddWithValue("@artista", produto.Artista);
                comando.Parameters.AddWithValue("@categoria", produto.Categoria);
                comando.Parameters.AddWithValue("@valor", produto.Valor);
                comando.Parameters.AddWithValue("@estado", produto.Estado);

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
        public bool deleteProduto(int id)
        {
            bool retorno = false;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "Delete from Produto where idProduto = @id";
                SqlCommand comando = new SqlCommand(comandoSQL, con);
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
