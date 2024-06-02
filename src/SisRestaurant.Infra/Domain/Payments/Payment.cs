using SisRestaurant.Infra.Domain.Shared;

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
