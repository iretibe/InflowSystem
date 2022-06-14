namespace InflowSystem.Shared.Infrastructure.Modules
{
    internal class ModuleRegistry : IModuleRegistry
    {
        private readonly List<ModuleBroadcastRegistration> _broadcastRegistrations = new();
        private readonly Dictionary<string, ModuleRequestRegistration> _requestRegistration = new ();

        public void AddBroadcastAction(Type requestType, Func<object, CancellationToken, Task> action)
        {
            if (string.IsNullOrWhiteSpace(requestType.Namespace))
            {
                throw new InvalidOperationException("Missing namespace.");
            }

            var registration = new ModuleBroadcastRegistration(requestType, action);

            _broadcastRegistrations.Add(registration);
        }

        public void AddRequestAction(string path, ModuleRequestRegistration registration)
        {
            if (path is null)
            {
                throw new InvalidOperationException("Request path cannot be null.");
            }

            if (registration.GetType().Namespace is null)
            {
                throw new InvalidOperationException("Namespace cannot be null.");
            }

            _requestRegistration.Add(path, registration);
        }

        public IEnumerable<ModuleBroadcastRegistration> GetBroadcastRegistrations(string key)
            => _broadcastRegistrations.Where(x => x.Key == key);

        public ModuleRequestRegistration GetRequestRegistration(string path)
            => _requestRegistration.TryGetValue(path, out var registration) ? registration : null;
    }
}
