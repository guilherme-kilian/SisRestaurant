namespace SisRestaurant.Models.Authentications;

public class AuthResponseModel
{
    public required string UserId { get; set; }
    public required string AuthorizationToken { get; set; }
    public string? RefreshToken { get; set; }
}
