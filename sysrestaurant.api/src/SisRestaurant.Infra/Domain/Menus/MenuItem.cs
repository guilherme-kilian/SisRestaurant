using SisRestaurant.Infra.Domain.Categories;
using SisRestaurant.Infra.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace SisRestaurant.Infra.Domain.Menus;

public class MenuItem : SoftDelete
{
    [Required]
    public string Name { get; private set; }

    [Range(0, double.MaxValue)]
    public double Price { get; private set; }

    [Required]
    public string Product { get; set; }

    [Required]
    public Category Category { get; private set; }

    [Required]
    public Menu Menu { get; private set; }
    
    public string? Picture { get; set; }

    protected MenuItem() { }

    public MenuItem(string name, double price, string product, Category category, string? picture)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(product);
        ArgumentOutOfRangeException.ThrowIfNegative(price);

        Product = product;
        Name = name;
        Price = price;
        Category = category;
        Picture = picture;
    }
}
