using Serilog;

namespace SisRestaurant.Api.Configuration
{
    public static class LoggingConfigs
    {
        public static WebApplicationBuilder AddLoggingConfigs(this WebApplicationBuilder builder)
        {
            builder.Services.AddSerilog(opt =>
            {
                opt.WriteTo.Console();
            });

            return builder;
        }
    }
}
