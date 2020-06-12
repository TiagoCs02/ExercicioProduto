using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
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
        public async Task<IActionResult> LoginAsync([FromForm]Cadastrousuario usuario)
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
                            Cadastrousuario usuarioGet = new Cadastrousuario();
                            string respostaAPIUser = await responseUser.Content.ReadAsStringAsync();
                            usuarioGet = JsonConvert.DeserializeObject<Cadastrousuario>(respostaAPIUser);
                            HttpContext.Session.SetString("_Nome", usuarioGet.Nome);
                            HttpContext.Session.SetInt32("_IdUser", usuarioGet.IdUsuario);

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
        public IActionResult cadUsuario()
        {
            ViewBag.Login = HttpContext.Session.GetInt32("_Login");
            ViewBag.Nome = HttpContext.Session.GetString("_Nome");
            if(HttpContext.Session.GetString("_Msg") != null)
            {
                ViewBag.Msg = HttpContext.Session.GetString("_Msg");
            }
            return View();
        }
        public async Task<IActionResult> CadastroAsync([FromForm] Cadastrousuario usuario)
        {
            using (var httpClient = new HttpClient())
            {
                if(usuario.Senha != usuario.ConfSenha)
                {
                    HttpContext.Session.SetString("_Msg", "Senhas não são iguais");
                    return RedirectToAction("cadUsuario");
                }
                usuario.Tipo = "1";
                using (var responseLogin = await httpClient.PostAsync("https://localhost:44308/api/usuario/", usuario, new JsonMediaTypeFormatter()))
                {

                    string respostaAPI = await responseLogin.Content.ReadAsStringAsync();
                    switch(respostaAPI)
                    {
                        case "0":
                            HttpContext.Session.SetString("_Msg", "Usuário já existe");
                            return RedirectToAction("cadUsuario");
                        case "1":
                            HttpContext.Session.SetString("_Msg", "Cadastro realizado com sucesso");
                            return RedirectToAction("Index", "Login");
                        case "2":
                            HttpContext.Session.SetString("_Msg", "Erro ao cadastrar usuário");
                            return RedirectToAction("cadUsuario");
                    }
                }
            }
            return RedirectToAction("cadUsuario");
        }
    }
}