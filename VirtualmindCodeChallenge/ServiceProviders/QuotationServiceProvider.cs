using System.Net;
using System.Net.Http;
using VirtualmindCodeChallenge.Interfaces;

namespace VirtualmindCodeChallenge.Providers
{
    public class QuotationServiceProvider
    {
        IQuotationService quotationService;

        public QuotationServiceProvider(string currency)
        {
            switch (currency.ToUpper())
            {
                case "DOLAR":
                    quotationService = new DollarQuotationService();
                    break;

                case "REAL":
                    quotationService = new RealQuotationService();
                    break;

                case "PESOS":
                    quotationService = new PesosQuotationService();
                    break;
            }
        }

        public HttpResponseMessage getQuotation()
        {
            if (quotationService != null)
                return quotationService.getQuotation();

            return new HttpResponseMessage(HttpStatusCode.Forbidden);
        }

    }
}