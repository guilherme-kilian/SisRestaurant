using SisRestaurant.Infra.Domain.Categories;
using SisRestaurant.Infra.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace SisRestaurant.Infra.Domain.Menus;

public class MenuItem : SoftDelete
{
    public required string Name { get; set; }

    [Range(0, double.MaxValue)]
    public double Price { get; set; }

    public required Category Category { get; set; }
}
