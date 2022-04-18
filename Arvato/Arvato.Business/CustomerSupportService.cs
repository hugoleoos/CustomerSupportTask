using Arvato.Domain.Adapters;
using Arvato.Domain.Exceptions;
using Arvato.Domain.Models;
using Arvato.Domain.Models.Validations;
using Arvato.Domain.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Arvato.Business
{
    public class CustomerSupportService : ICustomerSupportService
    {
        private readonly ILogger logger;
        private readonly ICustomerSupportDBAdapter customerSupportDBAdapter;

        public CustomerSupportService(
            ILogger<CustomerSupportService> logger,
            ICustomerSupportDBAdapter customerSupportDBAdapter)
        {
            this.logger = logger;
            this.customerSupportDBAdapter = customerSupportDBAdapter ??
                throw new ArgumentNullException(nameof(customerSupportDBAdapter));
        }

        public async Task<int> CreateCustomerSupportAsync(CustomerSupport customerSupport)
        {
            if (customerSupport is null)
            {
                throw new ArgumentNullException(nameof(customerSupport));
            }

            var validationResult = new CustomerSupportValidation().Validate(customerSupport);

            if (!validationResult.IsValid)
            {
                logger.LogError("Error: ", validationResult.ToString());
                throw new CreateSupportCoreException(validationResult.ToString());
            }

            return await customerSupportDBAdapter.CreateCustomerSupportAsync(customerSupport);
        }

        public async Task<CustomerSupport> GetCustomerSupportAsync(int id)
        {
            var customerSupport = await customerSupportDBAdapter.GetCustomerSupportAsync(id);

            if (customerSupport == null)
            {
                var errorMessage = "Customer not found";
                logger.LogError(errorMessage);
                throw new CreateSupportCoreException(errorMessage);
            }

            return customerSupport;
        }
    }   
}
