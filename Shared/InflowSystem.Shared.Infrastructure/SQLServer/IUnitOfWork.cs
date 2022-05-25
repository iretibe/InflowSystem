namespace InflowSystem.Shared.Infrastructure.SQLServer
{
    public interface IUnitOfWork
    {
        Task ExecuteAsync(Func<Task> action);
    }
}
