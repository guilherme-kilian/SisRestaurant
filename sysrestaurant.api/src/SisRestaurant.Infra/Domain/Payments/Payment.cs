using SisRestaurant.Infra.Domain.Reservations;
using SisRestaurant.Infra.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace SisRestaurant.Infra.Domain.Payments;

public class Payment : SoftDelete
{
    public PaymentStatus Status { get; set; }
    public double Value { get; set; }

    protected Payment() { }

    public Payment(PaymentStatus status, double value)
    {
        Status = status;
        Value = value;
    }
}

public enum PaymentStatus
{
    Paid,
    Canceled,
    Due,
}
