namespace SisRestaurant.Models.ReservationSettings;

public class ReservationSettingsModel
{
    public int Id { get; private set; }
    public bool PaymentRequired { get; set; }
    public TimeOnly StartAt { get; set; }
    public TimeOnly FinishAt { get; set; }
    public int Capacity { get; set; }
}
