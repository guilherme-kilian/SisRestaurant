using Hangfire;
using Microsoft.Extensions.Options;
using SisRestaurant.Infra.Services.Notification;
using SisRestaurant.Models;
using System.Net;
using System.Net.Mail;

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

            builder.Services.AddScoped(s =>
            {
                var appsSettings = s.GetRequiredService<IOptions<AppSettings>>().Value;

                return new SmtpClient(appsSettings.Mail.Server, appsSettings.Mail.Port)
                {
                    Credentials = new NetworkCredential(appsSettings.Mail.Email, appsSettings.Mail.Password),
                    EnableSsl = appsSettings.Mail.SSL
                };
            });

            return builder;
        }
    }
}
