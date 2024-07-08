using SisRestaurant.Models.MenuItems;
using System.ComponentModel.DataAnnotations;

namespace SisRestaurant.Models.Menus
{
    public class CreateMenuModel
    {
        public required string Name { get; set; }

        public required int RestaurantId { get; set; }

        public List<CreateMenuItemModel>? Items { get; set; }
    }
}
