using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;

namespace Site.Controllers
{
    public class ProdutoController : Controller
    {
        public async Task<IActionResult> DescricaoAsync(int id)
        {
            Produto produto = new Produto();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44308/api/produto/" + id.ToString()))
                {

                    string respostaAPI = await response.Content.ReadAsStringAsync();
                    produto = JsonConvert.DeserializeObject<Produto>(respostaAPI);

                }
            }
            return View(produto);
        }
    }
}