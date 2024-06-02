using SisRestaurant.Infra.Domain.Payments;
using SisRestaurant.Infra.Domain.Restaurants;
using SisRestaurant.Infra.Domain.Shared;
using SisRestaurant.Infra.Domain.Users;

namespace SisRestaurant.Infra.Domain.Reservations;

public class Reservation : SoftDelete
{
    public required User Customer { get; set; }
    public required Restaurant Restaurant { get; set; }
    public Payment? Payment { get; set; }
    public DateTime ReservedAt { get; set; }
    public string? Details { get; set; }
}
