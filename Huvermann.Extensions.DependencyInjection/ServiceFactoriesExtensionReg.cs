using Huvermann.Extensions.DependencyInjection.Abstractions.ServiceFactories;
using Huvermann.Extensions.DependencyInjection.Modularity;
using Huvermann.Extensions.DependencyInjection.ServiceFactories;
using Microsoft.Extensions.DependencyInjection;

namespace Huvermann.Extensions.DependencyInjection
{
    public static class ServiceFactoriesExtensionReg
    {
        public static IServiceCollection AddNamedServiceRegistration(this IServiceCollection services)
        {
            services.AddTransient<INameRegistrationService, NameRegistrationService>();
            services.AddTransient<INamedServiceProvider, NamedServiceProvider>();
            return services;
        }

        public static IServiceCollection AddModularity(this IServiceCollection services)
        {
            ModuleLoader.Configure(services);
            return services;
        }
    }
}
