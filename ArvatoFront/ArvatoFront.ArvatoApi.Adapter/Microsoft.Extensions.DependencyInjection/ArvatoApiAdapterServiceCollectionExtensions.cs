using ArvatoFront.ArvatoApi.Adapter.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;

namespace ArvatoFront.ArvatoApi.Adapter.Microsoft.Extensions.DependencyInjection
{
    public static class ArvatoApiAdapterServiceCollectionExtensions
    {
        public static IServiceCollection AddArvatoApiAdapter(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            services.AddRefitClient<IArvatoApiClient>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri(configuration.GetSection("ArvatoApiAdapter").Value);
                });

            services.AddScoped<IArvatoApiAdapter, ArvatoApiAdapter>();

            return services;
        }
    }
}
