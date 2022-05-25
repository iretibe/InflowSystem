using InflowSystem.Modules.Customers.Api;
using InflowSystem.Modules.Users.Api;
using InflowSystem.Shared.Infrastructure;
using InflowSystem.Shared.Infrastructure.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddCustomersModule();
builder.Services.AddUsersModule();

builder.Services.AddModularInfrastructure();
builder.Services.AddCommands();

//Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomersModule();

app.UseAuthorization();

app.MapControllers();

app.Run();
