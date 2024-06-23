namespace SisRestaurant.Infra.Domain.Shared;

public interface ISoftDelete
{
    bool Deleted { get; }
    DateTime DeletedAt { get; }
    void Delete();
}
