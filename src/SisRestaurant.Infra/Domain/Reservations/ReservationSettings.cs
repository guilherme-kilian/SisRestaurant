using SisRestaurant.Infra.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace SisRestaurant.Infra.Domain.Reservations;

public class ReservationSettings : Entity
{
    public bool PaymentRequired { get; set; }        
    public DateTime StartAt { get; set; }
    public DateTime FinishAt { get; set; }
    
    [Range(0, int.MaxValue)]
    public int Capacity { get; set; }
}
