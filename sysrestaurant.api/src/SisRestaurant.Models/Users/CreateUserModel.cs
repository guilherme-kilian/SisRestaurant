using System.ComponentModel.DataAnnotations;

namespace SisRestaurant.Models.Users;

public class CreateUserModel
{
    [Length(5, 200)]
    public required string FullName { get; set; }

    [Length(3, 200)]
    public required string UserName { get; set; }

    [EmailAddress]
    public required string Email { get; set; }

    [DataType(DataType.Password)]
    public required string Password { get; set; }

}
