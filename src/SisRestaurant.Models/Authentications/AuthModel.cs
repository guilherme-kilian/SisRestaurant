namespace SisRestaurant.Models.Authentications;

public class AuthModel
{
    public required string UserId { get; set; }
    public required string AuthorizationToken { get; set; }
    public string? RefreshToken { get; set; }
}
