//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;

//namespace InflowSystem.Shared.Infrastructure.Postgres
//{
//    public static class Extensions
//    {
//        internal static IServiceCollection AddPostgres(this IServiceCollection services)
//        {
//            var options = services.GetOptions<PostgresOptions>(sectionName: "postgres");
//            services.AddSingleton(options);
//            services.AddHostedService<DbContextAppInitializer>();

//            return services;
//        }

//        public static IServiceCollection AddPostgres<T>(this IServiceCollection services) where T : DbContext
//        {
//            var options = services.GetOptions<PostgresOptions>(sectionName: "postgres");
//            services.AddDbContext<T>(x => x.UseNpgsql(options.ConnectionString));

//            return services;
//        }
//    }
//}
