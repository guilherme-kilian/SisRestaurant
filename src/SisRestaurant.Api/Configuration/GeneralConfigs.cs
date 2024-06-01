namespace SisRestaurant.Api.Configuration
{
    public static class GeneralConfigs
    {
        public static WebApplicationBuilder AddGeneralConfigs(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            return builder;
        }
    }
}
