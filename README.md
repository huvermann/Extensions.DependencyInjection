# Extensions.DependencyInjection
DI Factories


#Example of service registration:

Create a Startup where a Servicecollection is created.

"AddNamedServiceRegistration": extents the servicecollection for Named Services
"AddModularity": extends the servicecollection to use all IRegistrationModule for service registration


```csharp
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
```
#Use of IRegistrationModule

Every class that implements IRegistrationModule is automatically used as service registration

```csharp

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

```
Example of usage:

```csharp
public class MainRunner
    {
        private IServiceByNameFactory<IPlugin> _pluginFactory;
        private IFactory<IFooService> _fooFactory;

        public MainRunner(IServiceByNameFactory<IPlugin> pluginFactory, IFactory<IFooService> fooFactory)
        {
            _pluginFactory = pluginFactory;
            _fooFactory = fooFactory;
        }

        public void Run()
        {
            var serviceWithNameA = _pluginFactory.GetServiceByName("NameA");
            Console.WriteLine("Got: " +serviceWithNameA.PluginName());
            var serviceWithNameB = _pluginFactory.GetServiceByName("NameIsB");
            Console.WriteLine("Got: " + serviceWithNameB.PluginName());

            Console.WriteLine("Resolve a foo class at runtime...");
            IFooService foo = _fooFactory.Create();
            foo.DoSomething();

            Console.WriteLine("Press any key.");
            Console.ReadLine();
        }
    }
```

