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
    public class PedidoController : Controller
    {
        public async Task<IActionResult> MeusPedidosAsync()
        {
            ViewBag.Login = HttpContext.Session.GetInt32("_Login");
            ViewBag.Nome = HttpContext.Session.GetString("_Nome");

            List<Pedido> pedList = new List<Pedido>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44308/api/pedido/venda/" + HttpContext.Session.GetInt32("_IdUser").ToString()))
                {

                    string respostaAPI = await response.Content.ReadAsStringAsync();
                    pedList = JsonConvert.DeserializeObject<List<Pedido>>(respostaAPI);

                }
            }
            return View(pedList);
        }
    }
}