using Microsoft.AspNetCore.Identity;
using SisRestaurant.Infra.Domain.Shared;
using System.Diagnostics.CodeAnalysis;

namespace SisRestaurant.Infra.Domain.Users;

public class User : IdentityUser, ISoftDelete
{
    public required string Name { get; set; }

    public bool Deleted { get; private set; }

    public DateTime DeletedAt { get; private set; }

    public void Delete()
    {
        Deleted = true;
        DeletedAt = DateTime.Now;
    }

    protected User() { }

    [SetsRequiredMembers]
    public User(string name, string userName, string email)
    {
        Name = name;
        UserName = userName;
        Email = email;
    }
}
