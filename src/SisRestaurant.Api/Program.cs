using SisRestaurant.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder
    .AddGeneralConfigs()
    .AddDbConfigs()
    .AddSwaggerConfigs()
    .AddAuthenticationConfigs()
    .AddDependencyInjectionConfigs();

var app = builder.Build();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
