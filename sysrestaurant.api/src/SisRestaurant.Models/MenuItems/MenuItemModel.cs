using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisRestaurant.Models.MenuItems
{
    public class MenuItemModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public double Price { get; set; }
        public required string CategoryName { get; set; }
        public string? Picture { get; set; }
        public required string Description { get; set; }
    }
}
