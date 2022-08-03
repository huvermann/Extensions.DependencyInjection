using Huvermann.Extensions.DependencyInjection.Abstractions.ServiceFactories;
using Microsoft.AspNetCore.Mvc;
using NamedServiceWebappDemo.NamedService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamedServiceWebappDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperationController : Controller
    {
        private readonly IServiceByNameFactory<IOperationService> _pluginFactory;

        public OperationController(IServiceByNameFactory<IOperationService> pluginFactory)
        {
            _pluginFactory = pluginFactory;
        }
        [HttpGet]
        public string Get(string operationName, double x, double y)
        {
            var operation = _pluginFactory.GetServiceByName(operationName);
            if (operation != null)
            {
                return $"Result: {operation.DoOperation(x, y)}";
            } else
            {
                return "Unknown operation: " + operationName;
            }
            
        }
    }
}
