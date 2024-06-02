using Serilog;
using SisRestaurant.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder
    .AddGeneralConfigs(out var appSettings)
    .AddAuthenticationConfigs(appSettings)
    .AddApiConfigs()
    .AddDbConfigs()
    .AddSwaggerConfigs()
    .AddLoggingConfigs()
    .AddDependencyInjectionConfigs();

var app = builder.Build();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseSerilogRequestLogging();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers()
    .RequireAuthorization();

app.Run();
