namespace SisRestaurant.Infra.Domain.Shared;

public class Entity
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public Entity()
    {
        CreatedAt = DateTime.Now;
    }
}
