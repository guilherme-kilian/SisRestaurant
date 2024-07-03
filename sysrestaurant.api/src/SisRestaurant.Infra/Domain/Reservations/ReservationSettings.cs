using SisRestaurant.Infra.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace SisRestaurant.Infra.Domain.Reservations;

public class ReservationSettings : Entity
{
    public bool PaymentRequired { get; set; }        
    public TimeOnly StartAt { get; set; }
    public TimeOnly FinishAt { get; set; }
    
    [Range(0, int.MaxValue)]
    public int Capacity { get; set; }

    protected ReservationSettings() { }

    public ReservationSettings(bool paymentRequired, TimeOnly startAt, TimeOnly finishAt, int capacity)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(capacity);

        PaymentRequired = paymentRequired;
        StartAt = startAt;
        FinishAt = finishAt;
        Capacity = capacity;
    }
}
