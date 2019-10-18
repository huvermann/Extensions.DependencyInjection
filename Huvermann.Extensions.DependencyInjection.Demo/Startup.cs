﻿using Huvermann.Extensions.DependencyInjection.Abstractions.ServiceFactories;
using Huvermann.Extensions.DependencyInjection.Demo.Runner;
using Huvermann.Extensions.DependencyInjection.Demo.Runner.Plugin;
using Huvermann.Extensions.DependencyInjection.ServiceFactories;
using Microsoft.Extensions.DependencyInjection;

namespace Huvermann.Extensions.DependencyInjection.Demo
{
    public class Startup
    {
        private readonly ServiceProvider _serviceProvider;

        public Startup()
        {
            IServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();

        }

        private IServiceCollection ConfigureServices(IServiceCollection services)
        {
            // Add the extension
            services.AddNamedServiceRegistration();

            // Add all plugins by name
            services.AddTransientByName<IPlugin, PluginA>("NameA");
            services.AddTransientByName<IPlugin, PluginA>("NameIsB");

            // Add a Factory for the plugin interface
            services.AddTransient<IServiceByNameFactory<IPlugin>, ServiceByNameFactory<IPlugin>>();

            // The class, where all the stuff is used.
            services.AddTransient<MainRunner>();
            return services;
        }

        public void Start()
        {
            var mainRunner = _serviceProvider.GetService<MainRunner>();
            mainRunner.Run();
        }
    }
}
