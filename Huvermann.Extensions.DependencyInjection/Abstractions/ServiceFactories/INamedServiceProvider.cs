namespace Huvermann.Extensions.DependencyInjection.Abstractions.ServiceFactories
{
    public interface INamedServiceProvider
    {
        TService GetServiceByName<TService>(string interfaceKey);
    }
}