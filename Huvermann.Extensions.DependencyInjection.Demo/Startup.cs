using Huvermann.Extensions.DependencyInjection.Abstractions.ServiceFactories;
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

            // Add module registration
            services.AddModularity();

            
            return services;
        }

        public void Start()
        {
            var mainRunner = _serviceProvider.GetService<MainRunner>();
            mainRunner.Run();
        }
    }
}
