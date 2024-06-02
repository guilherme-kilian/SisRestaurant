using Microsoft.OpenApi.Models;

namespace SisRestaurant.Api.Configuration
{
    public static class SwaggerConfigs
    {
        public static WebApplicationBuilder AddSwaggerConfigs(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(opt => {
                opt.AddSecurityDefinition("Jwt", new()
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer",
                    Type = SecuritySchemeType.ApiKey,
                });
                opt.AddSecurityRequirement(new()
                {
                    {
                        new()
                        {
                            Reference = new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });

            return builder;
        }
    }
}
