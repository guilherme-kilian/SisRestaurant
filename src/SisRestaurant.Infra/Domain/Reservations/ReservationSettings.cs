using SisRestaurant.Infra.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisRestaurant.Infra.Domain.Reservations;

public class ReservationSettings : Entity
{
    public bool PaymentRequired { get; set; }        
    public DateTime StartAt { get; set; }
    public DateTime FinishAt { get; set; }
    
    [Range(0, int.MaxValue)]
    public int Capacity { get; set; }
}
