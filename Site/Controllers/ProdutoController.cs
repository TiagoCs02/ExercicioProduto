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

        public IActionResult AddCarrinho(int id)
        {
            List<Carrinho> CarrinhoList = new List<Carrinho>();
            if (HttpContext.Session.GetString("_Carrinho") == null || HttpContext.Session.GetString("_Carrinho") == "")
            {
                Carrinho carrinho = new Carrinho();
                carrinho.IdProduto = id;
                carrinho.Quantidade = 1;
                CarrinhoList.Add(carrinho);
            }
            else
            {
                string recebe = HttpContext.Session.GetString("_Carrinho");
                CarrinhoList = JsonConvert.DeserializeObject<List<Carrinho>>(recebe);
                foreach(Carrinho carrinho in CarrinhoList)
                {
                    if(carrinho.IdProduto == id)
                    {
                        carrinho.Quantidade += 1;
                    }
                    else
                    {
                        Carrinho NewCarrinho = new Carrinho();
                        NewCarrinho.IdProduto = id;
                        NewCarrinho.Quantidade = 1;
                        CarrinhoList.Add(NewCarrinho);
                    }
                }

            }
            string envio = JsonConvert.SerializeObject(CarrinhoList);

            HttpContext.Session.SetString("_Carrinho", envio);

            return RedirectToAction("Carrinho", "Compra");
        }
    }
}