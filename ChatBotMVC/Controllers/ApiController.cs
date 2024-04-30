using ChatBotMVC.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Reflection;
using System.Web.Http.Description;

namespace ChatBotMVC.Controllers
{
    public class ApiController : Controller
    {
        private static HttpClient Http = new HttpClient();
        const string Baseurl = "https://api.openai.com/v1/chat/completions";
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ValidarChaveApi(ChaveAPIViewModel model)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("Index", "Chave inválida!");
                return View("Index", model);
            }
            else
            {
                return View("Index", model);
            }
        }


        public async Task<string> ChamadaApi(string key)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                // Seta a API KEY
                Http.DefaultRequestHeaders.Add("Authorization", $"Bearer {key}");

                // Conteúdo JSON para a chamada        
                string jsonContent = JsonConvert.SerializeObject(new
                {
                    model = "gpt-3.5-turbo",
                    messages = new[]
                    {
                        new {role = "user", content = ""}
                    },
                    max_tokens = 1
                });

                var body = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

                // Faz o POST pra API, passando o JSON serializado
                var response = await Http.PostAsync("", body);
                //              ^   resolução do problema

                return (response.StatusCode.ToString());
            }
        }
    }
}
