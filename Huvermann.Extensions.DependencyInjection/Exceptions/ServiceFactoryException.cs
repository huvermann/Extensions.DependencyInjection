using System;

namespace Huvermann.Extensions.DependencyInjection.Exceptions
{
    public class ServiceFactoryException : Exception
    {
        public ServiceFactoryException(string message) : base(message)
        {
        }
    }
}
