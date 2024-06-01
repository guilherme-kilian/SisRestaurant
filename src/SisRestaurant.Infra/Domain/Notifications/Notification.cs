using SisRestaurant.Infra.Domain.Shared;

namespace SisRestaurant.Infra.Domain.Notifications;

public class Notification : Entity
{
    public DateTime SendAt { get; set; }
    public bool Success { get; set; }
    public bool Finished { get; set; }
}
