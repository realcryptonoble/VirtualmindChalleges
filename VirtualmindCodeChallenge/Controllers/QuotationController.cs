using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VirtualmindCodeChallenge.Providers;

namespace VirtualmindCodeChallenge.Controllers
{
    public class QuotationController : ApiController
    {
        // GET api/Quotation
        public IEnumerable<string> Get() {
            yield return "Add to the url a / and one of the following currencies: pesos, dollar or real.\nFor example: \"/dolar\"";
        }

        // GET api/Quotation/dolar
        [HttpGet]
        public HttpResponseMessage Get(string currency) {
            var estrategia = new QuotationServiceProvider(currency);
            var httpResponse = estrategia.getQuotation();
            return httpResponse;
        }
    
    }
}
