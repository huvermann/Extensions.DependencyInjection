using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Huvermann.Extensions.DependencyInjection.Abstractions.Modularity
{
    public interface IRegistrationModule
    {
        void Configure(IServiceCollection services);
    }
}
