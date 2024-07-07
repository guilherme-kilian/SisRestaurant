using SisRestaurant.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisRestaurant.Models.Restaurants
{
    public class ShortRestaurantModel : FilterResult
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public bool Open { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Picture { get; set; }
        public required string Description { get; set; }
    }
}
