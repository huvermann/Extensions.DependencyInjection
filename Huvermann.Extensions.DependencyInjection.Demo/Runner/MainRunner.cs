using Huvermann.Extensions.DependencyInjection.Abstractions.ServiceFactories;
using Huvermann.Extensions.DependencyInjection.Demo.Runner.Plugin;
using System;
using System.Collections.Generic;
using System.Text;

namespace Huvermann.Extensions.DependencyInjection.Demo.Runner
{
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
}
