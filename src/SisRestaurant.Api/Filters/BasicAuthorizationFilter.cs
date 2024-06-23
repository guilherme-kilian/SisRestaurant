using Hangfire.Dashboard;
using Microsoft.Net.Http.Headers;
using SisRestaurant.Core.Utils;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;

namespace SisRestaurant.Api.Filters
{
    public class BasicAuthorizationFilter(string userName, string password) : IDashboardAuthorizationFilter
    {
        private readonly string _expectedBasicValue = new AuthenticationHeaderValue("Basic", HttpUtils.EncodeCredential(userName, password)).ToString();

        public bool Authorize([NotNull] DashboardContext context)
        {
            var httpContext = context.GetHttpContext();
            if (httpContext.Request.Headers.TryGetValue(HeaderNames.Authorization, out var authHeader))
                if (authHeader == _expectedBasicValue)
                    return true;

            httpContext.Response.Headers[HeaderNames.WWWAuthenticate] = "Basic realm=\"Hangfire Dashboard\" charset=\"UTF-8\"";
            httpContext.Response.StatusCode = 401;
            return false;
        }
    }
}
