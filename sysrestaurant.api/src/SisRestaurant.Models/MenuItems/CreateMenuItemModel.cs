using System.ComponentModel.DataAnnotations;

namespace SisRestaurant.Models.MenuItems
{
    public class CreateMenuItemModel
    {
        [MinLength(5)]
        public required string Name { get; set; }

        [MinLength(2)]
        public required string Product { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        public required string CategoryName { get; set; }
    }
}
