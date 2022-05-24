using InflowSystem.Shared.Abstractions.Commands;
using InflowSystem.Shared.Abstractions.Dispatchers;
using InflowSystem.Shared.Abstractions.Queries;

namespace InflowSystem.Shared.Infrastructure.Dispatchers
{
    internal sealed class InMemoryDispatcher : IDispatcher
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public InMemoryDispatcher(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }        

        public Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default) 
            where TResult : class
            => _queryDispatcher.QueryAsync(query, cancellationToken);

        public Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken) 
            where TCommand : class, ICommand
            => _commandDispatcher.SendAsync<TCommand>(command, cancellationToken);
    }
}
