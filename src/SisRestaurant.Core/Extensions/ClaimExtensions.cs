using System.Security.Claims;

namespace SisRestaurant.Core.Extensions;

public static class ClaimExtensions
{
    public static string GetUserId(this ClaimsPrincipal principal)
    {
        return principal.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
    }
}
