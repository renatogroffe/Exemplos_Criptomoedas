using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;

namespace ExemploASPNETCore1_1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(
            [FromServices]IConfiguration config)
        {
            Cotacao cotacao;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(
                    config.GetSection("Bitcoin:FOXBIT").Value).Result;
                response.EnsureSuccessStatusCode();
                
                using (var stream = response.Content
                    .ReadAsStreamAsync().Result)
                {
                    var serializer = new DataContractJsonSerializer(
                        typeof(Cotacao));
                    cotacao = serializer
                        .ReadObject(stream) as Cotacao;
                }
            }

            return View(cotacao);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}