using Arvato.Domain.Models;
using System.Threading.Tasks;

namespace Arvato.Domain.Services
{
    public interface ICustomerSupportService
    {
        /// <summary>
        /// Creates a new contacting Customer Support
        /// </summary>
        /// <param name="CustomerSuppport">
        /// Object with all atribuites to create a new contacting customer support
        /// </param>
        /// <returns>Customer's id</returns>
        Task<int> CreateCustomerSupportAsync(CustomerSupport costumerSupport);

        /// <summary>
        /// Gets customer's data by id
        /// </summary>
        /// <param name="id">Customer's id</param>
        /// <returns>Customer's data</returns>
        Task<CustomerSupport> GetCustomerSupportAsync(int id);
    }
}
