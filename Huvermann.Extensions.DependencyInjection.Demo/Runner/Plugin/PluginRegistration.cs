using Huvermann.Extensions.DependencyInjection.Abstractions.Modularity;
using Huvermann.Extensions.DependencyInjection.Abstractions.ServiceFactories;
using Huvermann.Extensions.DependencyInjection.ServiceFactories;
using Microsoft.Extensions.DependencyInjection;

namespace Huvermann.Extensions.DependencyInjection.Demo.Runner.Plugin
{
    public class PluginRegistration : IRegistrationModule
    {
        public void Configure(IServiceCollection services)
        {
            // Add all plugins by name
            services.AddTransientByName<IPlugin, PluginA>("NameA");
            services.AddTransientByName<IPlugin, PluginB>("NameIsB");

            // Add a Factory for the plugin interface
            services.AddTransient<IServiceByNameFactory<IPlugin>, ServiceByNameFactory<IPlugin>>();

            // Add a foo service factory.
            services.AddFactory<IFooService, Foo>();
            // The class, where all the stuff is used.
            services.AddTransient<MainRunner>();
        }
    }
}
