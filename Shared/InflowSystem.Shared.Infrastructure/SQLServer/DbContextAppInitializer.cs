using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace InflowSystem.Shared.Infrastructure.SQLServer
{
    internal class DbContextAppInitializer : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<DbContextAppInitializer> _logger;

        public DbContextAppInitializer(IServiceProvider serviceProvider, ILogger<DbContextAppInitializer> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var dbContextTypes = AppDomain.CurrentDomain.GetAssemblies()
                .Select(x => x.GetType())
                .Where(x => typeof(DbContext).IsAssignableFrom(x) && !x.IsInterface && x != typeof(DbContext));

            using var scope = _serviceProvider.CreateScope();

            foreach (var item in dbContextTypes)
            {
                var dbContext = scope.ServiceProvider.GetService(item) as DbContext;

                if (dbContext is null)
                {
                    continue;
                }

                _logger.LogInformation($"Running DB context for module {item.Name}...");

                await dbContext.Database.MigrateAsync(cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
