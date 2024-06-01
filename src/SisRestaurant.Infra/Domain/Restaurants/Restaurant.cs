using SisRestaurant.Infra.Domain.Menus;
using SisRestaurant.Infra.Domain.Reservations;
using SisRestaurant.Infra.Domain.Shared;
using SisRestaurant.Infra.Domain.Users;

namespace SisRestaurant.Infra.Domain.Restaurants;

public class Restaurant : SoftDelete
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required Menu Menu { get; set; }
    public required ReservationSettings Settings { get; set; }        
    public bool Open { get; set; }
    public List<Reservation> Reservations { get; set; } = [];
    public required User User { get; set; }
}
