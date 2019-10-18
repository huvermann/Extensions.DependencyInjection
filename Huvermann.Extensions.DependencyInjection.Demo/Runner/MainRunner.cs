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

        public MainRunner(IServiceByNameFactory<IPlugin> pluginFactory)
        {
            _pluginFactory = pluginFactory;
        }

        public void Run()
        {
            var serviceWithNameA = _pluginFactory.GetServiceByName("NameA");
            Console.WriteLine("Got: " +serviceWithNameA.PluginName());
            var serviceWithNameB = _pluginFactory.GetServiceByName("NameIsB");
            Console.WriteLine("Got: " + serviceWithNameB.PluginName());

            Console.WriteLine("Press any key.");
            Console.ReadLine();
        }
    }
}
