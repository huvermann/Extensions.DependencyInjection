using Huvermann.Extensions.DependencyInjection.Abstractions.ServiceFactories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Huvermann.Extensions.DependencyInjection.ServiceFactories
{
    public class NameRegistrationService : INameRegistrationService
    {
        private static Dictionary<string, Dictionary<string, Func<IServiceProvider, object>>> _registry = new Dictionary<string, Dictionary<string, Func<IServiceProvider, object>>>();
        public Dictionary<string, Dictionary<string, Func<IServiceProvider, object>>> NameRegistry => NameRegistrationService._registry;
    }
}
