using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisRestaurant.Infra.Exceptions
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(string? message) : base(message)
        {
        }
    }
}
