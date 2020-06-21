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
    public class ProdutoController : Controller
    {
        public async Task<IActionResult> DescricaoAsync(int id)
        {
            ViewBag.Login = HttpContext.Session.GetInt32("_Login");
            ViewBag.Nome = HttpContext.Session.GetString("_Nome");

            Cadastroproduto produto = new Cadastroproduto();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44308/api/produto/" + id.ToString()))
                {

                    string respostaAPI = await response.Content.ReadAsStringAsync();
                    produto = JsonConvert.DeserializeObject<Cadastroproduto>(respostaAPI);

                }
            }
            return View(produto);
        }

        public async Task<IActionResult> AddCarrinhoAsync(int id)
        {
            List<Carrinho> CarrinhoList = new List<Carrinho>();
            List<Carrinho> CarrinhoListNew = new List<Carrinho>();
            Estoque estoque = new Estoque();
            bool notnovo = false;
            if (HttpContext.Session.GetString("_Carrinho") == null || HttpContext.Session.GetString("_Carrinho") == "")
            {
                Carrinho carrinho = new Carrinho();
                carrinho.IdProduto = id;
                carrinho.Quantidade = 1;
                CarrinhoListNew.Add(carrinho);
            }
            else
            {
                string recebe = HttpContext.Session.GetString("_Carrinho");
                CarrinhoList = JsonConvert.DeserializeObject<List<Carrinho>>(recebe);
                foreach (Carrinho carrinho in CarrinhoList)
                {
                    using (var httpClient = new HttpClient())
                    {
                        using (var response = await httpClient.GetAsync("https://localhost:44308/api/estoque/produto/"+ carrinho.IdProduto.ToString()))
                        {

                            string respostaAPI = await response.Content.ReadAsStringAsync();
                            estoque = JsonConvert.DeserializeObject<Estoque>(respostaAPI);

                        }
                    }
                    if (carrinho.IdProduto == id)
                    {
                        if ((estoque.EstoqueAtual - estoque.EstoqueMin) >= (carrinho.Quantidade + 1))
                        {
                            carrinho.Quantidade += 1;
                        }
                        CarrinhoListNew.Add(carrinho);
                        notnovo = true;
                    }
                    else
                    {
                        CarrinhoListNew.Add(carrinho);
                    }
                }
                if (!notnovo) { 
                    Carrinho carrinhoNew = new Carrinho();
                    carrinhoNew.IdProduto = id;
                    carrinhoNew.Quantidade = 1;
                    CarrinhoListNew.Add(carrinhoNew);
                }
            }
            string envio = JsonConvert.SerializeObject(CarrinhoListNew);

            HttpContext.Session.SetString("_Carrinho", envio);

            return RedirectToAction("Carrinho", "Compra");
        }

        public IActionResult MenosCarrinho(int id)
        {
            List<Carrinho> CarrinhoList = new List<Carrinho>();
            List<Carrinho> CarrinhoListNew = new List<Carrinho>();
            bool notnovo = false;
            string recebe = HttpContext.Session.GetString("_Carrinho");
            CarrinhoList = JsonConvert.DeserializeObject<List<Carrinho>>(recebe);

            foreach (Carrinho carrinho in CarrinhoList)
            {
                if (carrinho.IdProduto == id)
                {
                    carrinho.Quantidade -= 1;
                    if (carrinho.Quantidade != 0)
                    {
                        CarrinhoListNew.Add(carrinho);
                    }
                    notnovo = true;
                }
                else
                {
                    CarrinhoListNew.Add(carrinho);
                }
            }
            string envio = JsonConvert.SerializeObject(CarrinhoListNew);

            HttpContext.Session.SetString("_Carrinho", envio);

            return RedirectToAction("Carrinho", "Compra");
        }

        public IActionResult TiraCarrinho(int id)
        {
            List<Carrinho> CarrinhoList = new List<Carrinho>();
            List<Carrinho> CarrinhoListNew = new List<Carrinho>();
            string recebe = HttpContext.Session.GetString("_Carrinho");
            CarrinhoList = JsonConvert.DeserializeObject<List<Carrinho>>(recebe);

            foreach (Carrinho carrinho in CarrinhoList)
            {
                if (carrinho.IdProduto != id)
                {
                    CarrinhoListNew.Add(carrinho);
                }
            }
            string envio = JsonConvert.SerializeObject(CarrinhoListNew);

            HttpContext.Session.SetString("_Carrinho", envio);

            return RedirectToAction("Carrinho", "Compra");
        }

        public async Task<IActionResult> ProdutosAsync()
        {
            ViewBag.Login = HttpContext.Session.GetInt32("_Login");
            ViewBag.Nome = HttpContext.Session.GetString("_Nome");

            List<Cadastroproduto> prodList = new List<Cadastroproduto>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44308/api/produto"))
                {

                    string respostaAPI = await response.Content.ReadAsStringAsync();
                    prodList = JsonConvert.DeserializeObject<List<Cadastroproduto>>(respostaAPI);

                }
            }
            return View(prodList);
        }

        public async Task<IActionResult> CategoriaAsync(string categoria)
        {
            ViewBag.Login = HttpContext.Session.GetInt32("_Login");
            ViewBag.Nome = HttpContext.Session.GetString("_Nome");

            List<Cadastroproduto> prodList = new List<Cadastroproduto>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44308/api/produto/categoria/" + categoria))
                {

                    string respostaAPI = await response.Content.ReadAsStringAsync();
                    prodList = JsonConvert.DeserializeObject<List<Cadastroproduto>>(respostaAPI);

                }
            }

            return View(prodList);
        }

        public async Task<IActionResult> PesquisaAsync([FromForm] Pesquisa pesquisa)
        {
            ViewBag.Login = HttpContext.Session.GetInt32("_Login");
            ViewBag.Nome = HttpContext.Session.GetString("_Nome");

            List<Cadastroproduto> prodList = new List<Cadastroproduto>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44308/api/produto/pesquisa/" + pesquisa.pesq))
                {

                    string respostaAPI = await response.Content.ReadAsStringAsync();
                    prodList = JsonConvert.DeserializeObject<List<Cadastroproduto>>(respostaAPI);

                }
            }
            return View(prodList);
        }

    }
}