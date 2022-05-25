using Microsoft.EntityFrameworkCore;

namespace InflowSystem.Shared.Infrastructure.SQLServer
{
    public abstract class SQLServerUnitOfWork<T> : IUnitOfWork where T : DbContext
    {
        private readonly T _dbContext;

        protected SQLServerUnitOfWork(T dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ExecuteAsync(Func<Task> action)
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                await action();
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
