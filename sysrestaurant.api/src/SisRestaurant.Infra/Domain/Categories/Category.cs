using SisRestaurant.Infra.Domain.Shared;

namespace SisRestaurant.Infra.Domain.Categories;

public class Category : SoftDelete
{
    public required string Name { get; set; }
}
