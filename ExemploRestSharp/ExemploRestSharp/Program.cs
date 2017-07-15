using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using RestSharp;
using Newtonsoft.Json;

namespace ExemploRestSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient(
                ConfigurationManager.AppSettings["APIBitcoin"]);
            var request = new RestRequest(
                "BRL/ticker?crypto_currency=BTC",
                Method.GET);

            IRestResponse response = client.Execute(request);
            string content = response.Content;
            Console.WriteLine($"JSON: {content}");

            var cotacao =
                JsonConvert.DeserializeObject<Cotacao>(content);
            Console.WriteLine($"Maior Valor: {cotacao.MaiorValor}");

            Console.ReadKey();
        }
    }
}