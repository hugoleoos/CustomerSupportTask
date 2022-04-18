using Arvato.DBAdapter;
using Arvato.DBAdapter.Context;
using Arvato.Domain.Adapters;
using Microsoft.EntityFrameworkCore;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DbRepositoryServiceCollectionExtensions
    {
        
        public static IServiceCollection AddDbAdapter(this IServiceCollection services, string dbconfiguration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            
            //services.AddScoped<ICustomerSupportDBAdapter, DbRepository>()
            //    .AddDbContext<DataBaseContext>(opt => opt.UseSqlServer(dbconfiguration));

            services.AddScoped<ICustomerSupportDBAdapter, DbRepository>()
                .AddDbContext<DataBaseContext>(opt => opt.UseInMemoryDatabase("test"));

            return services;
        }
    }
}
