using Arvato.Business;
using Arvato.Domain.Models;
using Arvato.Domain.Models.Validations;
using Arvato.Domain.Services;
using FluentValidation;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddBusiness(
            this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddTransient<IValidator<CustomerSupport>, CustomerSupportValidation>();

            services.AddScoped<ICustomerSupportService, CustomerSupportService>();

            return services;
        }
    }
}
