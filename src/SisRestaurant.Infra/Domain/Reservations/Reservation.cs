using SisRestaurant.Infra.Domain.Payments;
using SisRestaurant.Infra.Domain.Restaurants;
using SisRestaurant.Infra.Domain.Shared;
using SisRestaurant.Infra.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisRestaurant.Infra.Domain.Reservations;

public class Reservation : SoftDelete
{
    public required User Customer { get; set; }
    public required Restaurant Restaurant { get; set; }
    public Payment? Payment { get; set; }
    public DateTime ReservedAt { get; set; }
    public string? Details { get; set; }
}
