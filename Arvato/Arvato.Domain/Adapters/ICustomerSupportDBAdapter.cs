using Arvato.Domain.Models;
using System.Threading.Tasks;

namespace Arvato.Domain.Adapters
{
    public interface ICustomerSupportDBAdapter
    {
        /// <summary>
        /// this adpter is responsable for creating a custommer support in DB
        /// </summary>
        /// <param name="customerSupport">Customer's data</param>
        /// <returns>Customer's id</returns>
        Task<int> CreateCustomerSupportAsync(CustomerSupport customerSupport);

        /// <summary>
        /// Gets customer's data by id
        /// </summary>
        /// <param name="id">Customer's id</param>
        /// <returns>Customer's data</returns>
        Task<CustomerSupport> GetCustomerSupportAsync(int id);
    }
}
