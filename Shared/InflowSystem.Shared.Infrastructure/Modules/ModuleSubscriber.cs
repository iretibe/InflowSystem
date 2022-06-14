using InflowSystem.Shared.Abstractions.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace InflowSystem.Shared.Infrastructure.Modules
{
    internal sealed class ModuleSubscriber : IModuleSubscriber
    {
        private readonly IModuleRegistry _moduleRegistry;
        private readonly IServiceProvider _serviceProvider;

        public ModuleSubscriber(IModuleRegistry moduleRegistry, IServiceProvider serviceProvider)
        {
            _moduleRegistry = moduleRegistry;
            _serviceProvider = serviceProvider;
        }

        public IModuleSubscriber Subscribe<TRequest, TResponse>(string path, 
            Func<TRequest, IServiceProvider, CancellationToken, Task<TResponse>> action)
            where TRequest : class
            where TResponse : class
        {
            var registration = new ModuleRequestRegistration(typeof(TRequest), typeof(TResponse), 
                async(request, cancellationToken) =>
                {
                    using var scope = _serviceProvider.CreateScope();
                    return await action((TRequest)request, scope.ServiceProvider, cancellationToken);
                });

            _moduleRegistry.AddRequestAction(path, registration);

            return this;
        }
    }
}
