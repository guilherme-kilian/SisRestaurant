using SisRestaurant.Models.MenuItems;

namespace SisRestaurant.Models.Menus;

public class MenuModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required List<MenuItemModel> Items { get; set; }
}
