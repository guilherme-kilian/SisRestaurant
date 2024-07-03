using SisRestaurant.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisRestaurant.Models.Restaurants
{
    public class FilterRestaurantModel : FilterBase
    {
        public string? Name { get; set; }
        public List<string>? Category { get; set; }
        public bool? Open { get; set; }
    }
}
