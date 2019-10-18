using Huvermann.Extensions.DependencyInjection.Abstractions.ServiceFactories;
using Huvermann.Extensions.DependencyInjection.Exceptions;
using System;

namespace Huvermann.Extensions.DependencyInjection.ServiceFactories
{
    public class NamedServiceProvider : INamedServiceProvider
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly INameRegistrationService _nameRegistrationService;

        public NamedServiceProvider(IServiceProvider serviceProvider, INameRegistrationService nameRegistrationService)
        {
            _serviceProvider = serviceProvider;
            _nameRegistrationService = nameRegistrationService;
        }
        public TService GetServiceByName<TService>(string interfaceKey)
        {
            string servicename = typeof(TService).FullName;
            if (!_nameRegistrationService.NameRegistry.ContainsKey(servicename))
            {
                throw new ServiceFactoryException($"Service not registered! : {servicename}");
            }
            var interfaceRegistry = _nameRegistrationService.NameRegistry[servicename];
            if (!interfaceRegistry.ContainsKey(interfaceKey))
            {
                throw new ServiceFactoryException($"No Service registered for key: {interfaceKey}");
            }
            var instantiation = interfaceRegistry[interfaceKey];
            return (TService)instantiation(_serviceProvider);
        }
    }
}
