using SisRestaurant.Models.MenuItems;
using System.ComponentModel.DataAnnotations;

namespace SisRestaurant.Models.Menus
{
    public class CreateMenuModel
    {
        public required string Name { get; set; }

        public required int RestaurantId { get; set; }

        [Required]
        public required List<CreateMenuItemModel> Items { get; set; }
    }
}
