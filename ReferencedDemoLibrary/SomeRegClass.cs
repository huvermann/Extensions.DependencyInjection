using Huvermann.Extensions.DependencyInjection.Abstractions.Modularity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ReferencedDemoLibrary
{
    public class SomeRegClass : IRegistrationModule
    {
        public void Configure(IServiceCollection services)
        {
            Console.WriteLine("Module registered");
        }
    }
}
