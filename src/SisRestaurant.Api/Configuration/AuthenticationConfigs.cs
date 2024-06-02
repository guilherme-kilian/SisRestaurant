using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SisRestaurant.Models;
using System.Text;

namespace SisRestaurant.Api.Configuration;

public static class AuthenticationConfigs
{
    public static WebApplicationBuilder AddAuthenticationConfigs(this WebApplicationBuilder builder, AppSettings appSettings)
    {
        builder.Services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appSettings.Secret));
            opt.RequireHttpsMetadata = true;
            opt.SaveToken = true;
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidAudience = appSettings.Host,
                ValidIssuer = appSettings.Host,
                RequireExpirationTime = true,
                IssuerSigningKey = key,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });

        return builder;
    }
}
