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
    }
}