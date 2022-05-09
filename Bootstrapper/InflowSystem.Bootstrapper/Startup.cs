using InflowSystem.Modules.Customers.Api;
using InflowSystem.Shared.Infrastructure;

namespace InflowSystem.Bootstrapper
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCustomersModule();
            services.AddModularInfrastructure();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            app.UseRouting();
            app.UseCustomersModule();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", context => context.Response.WriteAsync("Inflow System API"));
                //endpoints.MapModuleInfo();
            });
        }
    }
}
