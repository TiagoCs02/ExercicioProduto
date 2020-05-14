using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;

namespace Site.Controllers
{
    public class ProdutoController : Controller
    {
        public async Task<IActionResult> DescricaoAsync(int id)
        {
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
    }
}