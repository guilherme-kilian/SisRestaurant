using Microsoft.EntityFrameworkCore;
using SisRestaurant.Infra.Domain;

namespace SisRestaurant.Api.Configuration;

public static class DbConfigs
{
    public static WebApplicationBuilder AddDbConfigs(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("Default");
        builder.Services.AddDbContext<SisRestaurantContext>(opt => opt.UseSqlServer(connectionString));

        return builder;
    }
}
