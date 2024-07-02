using SisRestaurant.Infra.Domain.Payments;
using SisRestaurant.Infra.Domain.Restaurants;
using SisRestaurant.Infra.Domain.Shared;
using SisRestaurant.Infra.Domain.Users;
using System.ComponentModel.DataAnnotations;

namespace SisRestaurant.Infra.Domain.Reservations;

public class Reservation : SoftDelete
{
    [Required]
    public User Customer { get; private set; }

    [Required]
    public Restaurant Restaurant { get; private set; }
    public Payment? Payment { get; private set; }
    public DateTime ReservedAt { get; private set; }
    public string? Details { get; private set; }

    [Range(1, int.MaxValue)]
    public int Count { get; private set; }

    protected Reservation() { }

    public Reservation(User customer, Restaurant restaurant, Payment? payment, DateTime reservedAt, string? details, int count)
    {
        ArgumentNullException.ThrowIfNull(customer);
        ArgumentNullException.ThrowIfNull(restaurant);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(count);

        Customer = customer;
        Restaurant = restaurant;
        Payment = payment;
        ReservedAt = reservedAt;
        Details = details;
        Count = count;
    }
}
