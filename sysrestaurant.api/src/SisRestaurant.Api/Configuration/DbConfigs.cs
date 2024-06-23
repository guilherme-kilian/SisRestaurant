using Microsoft.EntityFrameworkCore;
using SisRestaurant.Infra.Domain;
using SisRestaurant.Infra.Domain.Users;

namespace SisRestaurant.Api.Configuration;

public static class DbConfigs
{
    public static WebApplicationBuilder AddDbConfigs(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("Default");
        builder.Services.AddDbContext<SisRestaurantContext>(opt => opt.UseSqlServer(connectionString));
        builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<SisRestaurantContext>();

        return builder;
    }
}
