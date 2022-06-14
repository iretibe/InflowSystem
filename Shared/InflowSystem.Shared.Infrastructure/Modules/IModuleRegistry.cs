namespace InflowSystem.Shared.Infrastructure.Modules
{
    internal interface IModuleRegistry
    {
        ModuleRequestRegistration GetRequestRegistration(string path);
        IEnumerable<ModuleBroadcastRegistration> GetBroadcastRegistrations(string key);
        void AddBroadcastAction(Type requestType, Func<object, CancellationToken, Task> action);
        void AddRequestAction(string path, ModuleRequestRegistration registration);
    }
}
