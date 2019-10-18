# Extensions.DependencyInjection
DI Factories


#Example of service registration:

```csharp
private IServiceCollection ConfigureServices(IServiceCollection services)
        {
            // Add the extension
            services.AddNamedServiceRegistration();

            // Add all plugins by name
            services.AddTransientByName<IPlugin, PluginA>("NameA");
            services.AddTransientByName<IPlugin, PluginB>("NameIsB");

            // Add a Factory for the plugin interface
            services.AddTransient<IServiceByNameFactory<IPlugin>, ServiceByNameFactory<IPlugin>>();

            // Add a foo service factory.
            services.AddFactory<IFooService, Foo>();
            // The class, where all the stuff is used.
            services.AddTransient<MainRunner>();
            return services;
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

