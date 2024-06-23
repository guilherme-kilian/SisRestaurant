namespace SisRestaurant.Models;

public class AppSettings
{
    public required string Secret { get; set; }
    public required string Host { get; set; }
    public required string HFUser { get; set; }
    public required string HFPassword { get; set; }
}
