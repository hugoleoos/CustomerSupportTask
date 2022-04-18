using ArvatoFront.ArvatoApi.Adapter.Interfaces;
using System;
using System.Threading.Tasks;

namespace ArvatoFront.ArvatoApi.Adapter
{
    public class ArvatoApiAdapter : IArvatoApiAdapter
    {
        private readonly IArvatoApiClient arvatoApiClient;

        public ArvatoApiAdapter(IArvatoApiClient arvatoApiClient)
        {
            this.arvatoApiClient = arvatoApiClient
                ?? throw new ArgumentNullException(nameof(arvatoApiClient));
        }

        public async Task<int> CreateCustomerSupportAsync(CustomerSupportPost costumerSupport)
        {
            return await arvatoApiClient.CreateCustomerSupportAsync(costumerSupport);
        }
    }
}
