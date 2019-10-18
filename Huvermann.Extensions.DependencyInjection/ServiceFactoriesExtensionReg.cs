using Huvermann.Extensions.DependencyInjection.Abstractions.ServiceFactories;
using Huvermann.Extensions.DependencyInjection.ServiceFactories;
using Microsoft.Extensions.DependencyInjection;

namespace Huvermann.Extensions.DependencyInjection
{
    public static class ServiceFactoriesExtensionReg
    {
        public static IServiceCollection AddNamedServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<INameRegistrationService, NameRegistrationService>();
            services.AddTransient<INamedServiceProvider, NamedServiceProvider>();
            return services;
        }
    }
}
