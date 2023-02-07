using System;
using System.Net;
using System.Net.Http;
using VirtualmindCodeChallenge.Interfaces;

namespace VirtualmindCodeChallenge.Providers
{
    internal class RealQuotationService : IQuotationService
    {
        public RealQuotationService()
        {
            Console.WriteLine("Accesing RealQuotationService");
        }

        public HttpResponseMessage getQuotation()
        {
            return new HttpResponseMessage(HttpStatusCode.Forbidden);
        }
    }
}