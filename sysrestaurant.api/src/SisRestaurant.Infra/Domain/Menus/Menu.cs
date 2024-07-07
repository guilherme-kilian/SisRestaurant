using SisRestaurant.Infra.Domain.Restaurants;
using SisRestaurant.Infra.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace SisRestaurant.Infra.Domain.Menus;

public class Menu : SoftDelete
{
    [Required]
    public string Name { get; set; }

    [Required]
    public Restaurant Restaurant { get; set; }

    public List<MenuItem> Items { get; set; }

    protected Menu() { }

    public Menu(string name, List<MenuItem> items, Restaurant restaurant)
    {
        ArgumentNullException.ThrowIfNull(restaurant);
        ArgumentException.ThrowIfNullOrEmpty(name, "Name");

        Restaurant = restaurant;
        Name = name;
        Items = items;
    }

    public void AddItem(MenuItem item)
    {
        Items.Add(item);
    }

    public void RemoveItem(MenuItem item)
    {
        Items.Remove(item);
    }
}
