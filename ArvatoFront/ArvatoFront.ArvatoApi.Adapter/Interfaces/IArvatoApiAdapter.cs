using System.Threading.Tasks;

namespace ArvatoFront.ArvatoApi.Adapter.Interfaces
{
    public interface IArvatoApiAdapter
    {
        /// <summary>
        /// Creates a new contacting Customer Support
        /// </summary>
        /// <param name="CustomerSuppport">
        /// Object with all atribuites to create a new contacting customer support
        /// </param>
        /// <returns>Customer's id</returns>
        Task<int> CreateCustomerSupportAsync(CustomerSupportPost costumerSupport);
    }
}
