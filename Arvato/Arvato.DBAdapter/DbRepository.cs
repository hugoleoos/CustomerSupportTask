using Arvato.DBAdapter.Context;
using Arvato.Domain.Adapters;
using Arvato.Domain.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Arvato.DBAdapter
{
    class DbRepository : ICustomerSupportDBAdapter
    {
        private readonly DataBaseContext context;
        private readonly IMapper mapper;

        public DbRepository(DataBaseContext context, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> CreateCustomerSupportAsync(CustomerSupport customerSupport)
        {
            var customerSupportAdd = mapper.Map<CustomerSupport, Entities.CustomerSupport>(customerSupport);

            context.Add(customerSupportAdd);

            await context.SaveChangesAsync();

            return customerSupportAdd.Id;
        }

        public async Task<CustomerSupport> GetCustomerSupportAsync(int id)
        {
            var customerSupport = await context.CustomerSupports.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            return mapper.Map<Entities.CustomerSupport, CustomerSupport>(customerSupport);
        }
    }
}
