using SisRestaurant.Models.MenuItems;
using System.ComponentModel.DataAnnotations;

namespace SisRestaurant.Models.Menus
{
    public class CreateMenuModel
    {
        public int RestaurantId { get; set; }

        [Required]
        public required List<CreateMenuItemModel> Items { get; set; }
    }
}
