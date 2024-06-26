using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisRestaurant.Models.MenuItems
{
    public class CreateMenuItemModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int RestaurantId { get; set; }

        [MinLength(5)]
        public required string Name { get; set; }

        [MinLength(5)]
        public required string Product { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        public required string CategoryName { get; set; }
    }
}
