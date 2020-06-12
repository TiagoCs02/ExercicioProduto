using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;

namespace Site.Controllers
{
    public class CompraController : Controller
    {
        public async Task<IActionResult> CarrinhoAsync()
        {
            string recebe = HttpContext.Session.GetString("_Carrinho");

            ViewBag.Login = HttpContext.Session.GetInt32("_Login");
            ViewBag.Nome = HttpContext.Session.GetString("_Nome");

            List<Cadastroproduto> ProdutoList = new List<Cadastroproduto>();
            if(recebe != null && recebe != "")
            {
                List<Carrinho> CarrinhoList = JsonConvert.DeserializeObject<List<Carrinho>>(recebe);

                using (var httpClient = new HttpClient())
                {
                    foreach (Carrinho carrinho in CarrinhoList)
                    {
                        Cadastroproduto produto = new Cadastroproduto();
                        using (var response = await httpClient.GetAsync("https://localhost:44308/api/produto/" + carrinho.IdProduto.ToString()))
                        {
                            string respostaAPI = await response.Content.ReadAsStringAsync();
                            produto = JsonConvert.DeserializeObject<Cadastroproduto>(respostaAPI);
                            produto.Quantidade = carrinho.Quantidade;
                            ProdutoList.Add(produto);
                        }
                    }
                }
            }
            return View(ProdutoList);
        }

        public async Task<IActionResult> EntregaAsync()
        {
            ViewBag.Login = HttpContext.Session.GetInt32("_Login");
            ViewBag.Nome = HttpContext.Session.GetString("_Nome");

            Cadastrousuario usuario = new Cadastrousuario();
            string id = HttpContext.Session.GetInt32("_IdUser").ToString();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44308/api/usuario/" + id))
                {
                    Cadastrousuario usuarioGet = new Cadastrousuario();
                    string resposta = await response.Content.ReadAsStringAsync();
                    usuario = JsonConvert.DeserializeObject<Cadastrousuario>(resposta);
                    Endereco endereco = new Endereco
                    {
                        Logradouro = usuario.Logradouro,
                        Numero = usuario.Numero,
                        Cep = usuario.Cep,
                        Cidade = usuario.Cidade,
                        Uf = usuario.Uf
                    };
                    string enderecoJson = JsonConvert.SerializeObject(endereco);
                    HttpContext.Session.SetString("_Endereco", enderecoJson);
                }
            }
            return View(usuario);
        }

        public async Task<IActionResult> ConfirmacaoAsync()
        {
            ViewBag.Login = HttpContext.Session.GetInt32("_Login");
            ViewBag.Nome = HttpContext.Session.GetString("_Nome");

            string recebe = HttpContext.Session.GetString("_Carrinho");
            ViewBag.Endereco = HttpContext.Session.GetString("_Endereco");
            List<Cadastroproduto> ProdutoList = new List<Cadastroproduto>();
            if (recebe != null && recebe != "")
            {
                List<Carrinho> CarrinhoList = JsonConvert.DeserializeObject<List<Carrinho>>(recebe);

                using (var httpClient = new HttpClient())
                {
                    foreach (Carrinho carrinho in CarrinhoList)
                    {
                        Cadastroproduto produto = new Cadastroproduto();
                        using (var response = await httpClient.GetAsync("https://localhost:44308/api/produto/" + carrinho.IdProduto.ToString()))
                        {
                            string respostaAPI = await response.Content.ReadAsStringAsync();
                            produto = JsonConvert.DeserializeObject<Cadastroproduto>(respostaAPI);
                            produto.Quantidade = carrinho.Quantidade;
                            ProdutoList.Add(produto);
                        }
                    }
                }
            }
            return View(ProdutoList);
        }
    }
}