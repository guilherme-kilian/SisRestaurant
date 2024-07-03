using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisRestaurant.Models.Shared
{
    public class FilterBase
    {
        [Range(1, 1000)]
        public int Take { get; set; }

        [Range(0, int.MaxValue)]
        public int Skip { get; set; }
    }
}
