using Hangfire;
using SisRestaurant.Infra.Services.Notification;

namespace SisRestaurant.Api.Configuration
{
    public static class ServiceConfigs
    {
        public static WebApplicationBuilder AddServiceConfigs(this WebApplicationBuilder builder)
        {

            builder.Services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(builder.Configuration.GetConnectionString("Default"), new Hangfire.SqlServer.SqlServerStorageOptions
                {
                    SchemaName = "HF",
                }));

            builder.Services.AddHangfireServer();

            builder.Services.AddScoped<INotificationSender, EmailSender>();

            return builder;
        }
    }
}
