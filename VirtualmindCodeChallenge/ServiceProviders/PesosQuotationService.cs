using System;
using System.Net;
using System.Net.Http;
using VirtualmindCodeChallenge.Interfaces;

namespace VirtualmindCodeChallenge.Providers
{
    internal class PesosQuotationService : IQuotationService
    {
        public PesosQuotationService()
        {
            Console.WriteLine("Accesing PesosQuotationService");
        }

        public HttpResponseMessage getQuotation()
        {
            return new HttpResponseMessage(HttpStatusCode.Forbidden);
        }
    }
}