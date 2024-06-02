namespace SisRestaurant.Api.Configuration;

public static class ApiConfigs
{
    public static WebApplicationBuilder AddApiConfigs(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        return builder;
    }
}
