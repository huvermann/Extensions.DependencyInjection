using System;
using System.Collections.Generic;

namespace Huvermann.Extensions.DependencyInjection.Abstractions.ServiceFactories
{
    public interface INameRegistrationService
    {
         Dictionary<string, Dictionary<string, Func<IServiceProvider, object>>> NameRegistry { get; }
    }
}