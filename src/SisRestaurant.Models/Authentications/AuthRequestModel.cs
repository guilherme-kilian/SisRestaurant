using System.ComponentModel.DataAnnotations;

namespace SisRestaurant.Models.Authentications;

public class AuthRequestModel
{
    [EmailAddress]
    public required string Email { get; set; }

    [DataType(DataType.Password)]
    public required string Password { get; set; }
}
