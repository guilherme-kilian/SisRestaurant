using Hangfire;
using Hangfire.Dashboard;
using Serilog;
using SisRestaurant.Api.Configuration;
using SisRestaurant.Api.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder
    .AddGeneralConfigs(out var appSettings)
    .AddAuthenticationConfigs(appSettings)
    .AddApiConfigs()
    .AddDbConfigs()
    .AddSwaggerConfigs()
    .AddLoggingConfigs()
    .AddDependencyInjectionConfigs()
    .AddServiceConfigs();

var app = builder.Build();

app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

app.UseSwagger();
app.UseSwaggerUI();

app.UseHangfireDashboard("/hangfire", new DashboardOptions()
{
    Authorization = [new BasicAuthorizationFilter(appSettings.HFUser, appSettings.HFPassword)],
    DarkModeEnabled = true,
});

app.UseHttpsRedirection();
app.UseSerilogRequestLogging();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers().RequireAuthorization();

app.Run();
