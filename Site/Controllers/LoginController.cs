using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;

namespace Site.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromForm]Usuario usuario)
        {
            using (var httpClient = new HttpClient())
            {
                using (var responseLogin = await httpClient.PostAsync("https://localhost:44308/api/login/", usuario, new JsonMediaTypeFormatter()))
                {

                    string respostaAPI = await responseLogin.Content.ReadAsStringAsync();
                    if(respostaAPI != "0")
                    {
                        using (var responseUser = await httpClient.GetAsync("https://localhost:44308/api/usuario/" + respostaAPI))
                        {
                            Usuario usuarioGet = new Usuario();
                            string respostaAPIUser = await responseUser.Content.ReadAsStringAsync();
                            usuarioGet = JsonConvert.DeserializeObject<Usuario>(respostaAPIUser);
                            HttpContext.Session.SetString("_Nome", usuarioGet.nome);
                        }

                            HttpContext.Session.SetInt32("_Login", 1);

                        return RedirectToAction("Index", "Home");
                    }

                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("_Nome");
            HttpContext.Session.Remove("_Login");
            return RedirectToAction("Index", "Home");
        }
    }
}