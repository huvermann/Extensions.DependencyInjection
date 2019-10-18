using System;
using System.Collections.Generic;
using System.Text;

namespace Huvermann.Extensions.DependencyInjection.Abstractions.ServiceFactories
{
    public interface IServiceByNameFactory<TService>
    {
        TService GetServiceByName(string interfaceKey);
    }
}
