using SisRestaurant.Infra.Domain.Restaurants;
using SisRestaurant.Infra.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace SisRestaurant.Infra.Domain.Menus;

public class Menu : SoftDelete
{
    [Required]
    public Restaurant Restaurant { get; set; }

    [Required]
    public List<MenuItem> Items { get; set; }

    protected Menu() { }

    public Menu(List<MenuItem> items, Restaurant restaurant)
    {
        if(items.Count == 0) throw new ArgumentException("EmptyItems");
        ArgumentNullException.ThrowIfNull(restaurant);

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
