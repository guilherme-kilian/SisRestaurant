namespace SisRestaurant.Models.Reservations;

public class ReservationModel
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int Count { get; set; }
    public string? Details { get; set; }
}
