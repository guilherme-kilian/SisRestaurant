namespace SisRestaurant.Infra.Domain.Shared;

public class Entity
{
    public int Id { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public Entity()
    {
        CreatedAt = DateTime.Now;
    }
}
