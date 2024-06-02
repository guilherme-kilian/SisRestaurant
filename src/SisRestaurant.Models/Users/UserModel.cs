namespace SisRestaurant.Models.Users;

public class UserModel
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public required string UserName { get; set; }
    public required string Name { get; set; }
}
