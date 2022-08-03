using Huvermann.Extensions.DependencyInjection.Abstractions.ServiceFactories;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NamedServiceWebappDemo.NamedService
{
    public class DemoBackgroundService : BackgroundService
    {
        private readonly IServiceByNameFactory<IOperationService> _pluginFactory;

        public DemoBackgroundService(IServiceByNameFactory<IOperationService> pluginFactory)
        {
            _pluginFactory = pluginFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var mulitply = _pluginFactory.GetServiceByName("Multiply");
                var add = _pluginFactory.GetServiceByName("Add");
                Console.WriteLine($"{add.DoOperation(5, 7)}");
                Console.WriteLine($"{mulitply.DoOperation(5, 7)}");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
