using SisRestaurant.Models.MenuItems;

namespace SisRestaurant.Models.Menus;

public class MenuModel
{
    public required List<MenuItemModel> Items { get; set; }
}
