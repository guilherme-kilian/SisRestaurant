using Microsoft.AspNetCore.Identity;
using SisRestaurant.Infra.Domain.Reservations;
using SisRestaurant.Infra.Domain.Restaurants;
using SisRestaurant.Infra.Domain.Shared;
using System.Diagnostics.CodeAnalysis;

namespace SisRestaurant.Infra.Domain.Users;

public class User : IdentityUser, ISoftDelete
{
    public required string Name { get; set; }

    public bool Deleted { get; private set; }

    public DateTime? DeletedAt { get; private set; }

    public List<Restaurant> Restaurants { get; private set; }

    public List<Reservation> Reservations { get; private set; }

    public void Delete()
    {
        Deleted = true;
        DeletedAt = DateTime.Now;
    }

    public bool HasPermission(int restaurantId) => Restaurants.Any(i => i.Id == restaurantId && !i.Deleted);
    
    public bool HasReservation(int reservationId) => Reservations.Any(i => i.Id == reservationId && !i.Deleted);

    public Restaurant GetRestaurant(int restaurantId) => Restaurants.First(i => i.Id == restaurantId && !i.Deleted);

    public Reservation GetReservation(int reservationId) => Reservations.First(i => i.Id == reservationId && !i.Deleted);

    protected User() { }

    [SetsRequiredMembers]
    public User(string name, string userName, string email)
    {
        Name = name;
        UserName = userName;
        Email = email;
    }
}
