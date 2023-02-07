using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using VirtualmindCodeChallenge.Interfaces;

namespace VirtualmindCodeChallenge.Providers
{
    internal class DollarQuotationService : IQuotationService
    {
        private const string dollarQuotationSource = "https://www.bancoprovincia.com.ar/Principal/Dolar";

        public DollarQuotationService()
        {
            Console.WriteLine("Accesing DollarQuotationService");
        }
    
        public HttpResponseMessage getQuotation()
        {
            HttpClient client = new HttpClient() {
                BaseAddress = new Uri(dollarQuotationSource)
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync(dollarQuotationSource).Result;

            if (response.IsSuccessStatusCode)
            {
                return response;
            }

            return new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }

    }
}