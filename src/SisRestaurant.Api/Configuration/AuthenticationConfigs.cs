using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SisRestaurant.Api.Configuration;

public static class AuthenticationConfigs
{
    public static WebApplicationBuilder AddAuthenticationConfigs(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opt =>
        {
            var secret = builder.Configuration.GetValue<string>("Secret") ?? throw new ArgumentException("Secret cannot be null");
            var host = builder.Configuration.GetValue<string>("Host") ?? throw new ArgumentException("Secret cannot be null");
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
            opt.RequireHttpsMetadata = true;
            opt.SaveToken = true;
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidAudience = host,
                ValidIssuer = host,
                IssuerSigningKey = key,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });

        return builder;
    }
}
