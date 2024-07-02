using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisRestaurant.Models.Reservations
{
    public class CreateReservationModel
    {
        public int RestaurantId { get; set; }

        public DateTime Date { get; set; }

        public int Count { get; set; }

        public string? Details { get; set; }
    }
}
