namespace SisRestaurant.Infra.Domain.Shared;

public class SoftDelete : Entity, ISoftDelete
{
    public bool Deleted { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    public void Delete()
    {
        Deleted = true;
        DeletedAt = DateTime.UtcNow;
    }
}
