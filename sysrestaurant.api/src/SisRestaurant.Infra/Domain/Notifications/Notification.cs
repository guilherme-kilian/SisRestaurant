using SisRestaurant.Infra.Domain.Shared;

namespace SisRestaurant.Infra.Domain.Notifications;

public class Notification : Entity
{
    public DateTime SendAt { get; private set; }
    public bool Success { get; private set; }
    public bool Finished { get; private set; }

    public Notification(bool success, bool finished)
    {
        SendAt = DateTime.UtcNow;
        Success = success;
        Finished = finished;
    }
}
