using InflowSystem.Shared.Abstractions.Commands;
using InflowSystem.Shared.Abstractions.Queries;

namespace InflowSystem.Shared.Abstractions.Dispatchers
{
    public interface IDispatcher
    {
        Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) 
            where TCommand : class, ICommand;
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default)
            where TResult : class;
    }
}
