using System.Net.Http;

namespace VirtualmindCodeChallenge.Interfaces
{
    interface IQuotationService
    {

        HttpResponseMessage getQuotation();

    }
}
