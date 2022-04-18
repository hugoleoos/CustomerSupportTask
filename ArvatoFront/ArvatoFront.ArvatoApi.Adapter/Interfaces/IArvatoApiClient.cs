using Refit;
using System.Threading.Tasks;

namespace ArvatoFront.ArvatoApi.Adapter.Interfaces
{
    public interface IArvatoApiClient
    {
        [Post("/CustomerSupport")]
        Task<int> CreateCustomerSupportAsync(
            [Body] CustomerSupportPost customerSupportPost);
    }
}
