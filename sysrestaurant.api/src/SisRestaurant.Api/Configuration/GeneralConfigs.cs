using SisRestaurant.Models;

namespace SisRestaurant.Api.Configuration;

public static class GeneralConfigs
{
    public static WebApplicationBuilder AddGeneralConfigs(this WebApplicationBuilder builder, out AppSettings appSettings)
    {
        builder.Services.AddAutoMapper(typeof(MappingProfile));

        var section = builder.Configuration.GetSection(nameof(AppSettings));
        builder.Services.Configure<AppSettings>(section);
        appSettings = section.Get<AppSettings>() ?? throw new ArgumentNullException(nameof(appSettings));

        return builder;
    }
}
