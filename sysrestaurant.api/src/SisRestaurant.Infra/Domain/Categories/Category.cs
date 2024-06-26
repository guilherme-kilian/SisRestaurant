using SisRestaurant.Infra.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace SisRestaurant.Infra.Domain.Categories;

public class Category : SoftDelete
{
    [Required]
    public string Name { get; private set; }

    protected Category() { }

    public Category(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name;
    }
}
