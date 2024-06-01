using SisRestaurant.Infra.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisRestaurant.Infra.Domain.Payments;

public class Payment : SoftDelete
{
    public PaymentStatus Status { get; set; }
    public double Value { get; set; }
}

public enum PaymentStatus
{
    Paid,
    Canceled,
    Due,
}
