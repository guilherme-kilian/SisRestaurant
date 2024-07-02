namespace SisRestaurant.Models;

public class AppSettings
{
    public required string Secret { get; set; }
    public required string Host { get; set; }
    public required string HFUser { get; set; }
    public required string HFPassword { get; set; }    
    public required MailSettings Mail { get; set; }
}

public class MailSettings
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Server { get; set; }
    public int Port { get; set; }
    public bool SSL { get; set; }
}
