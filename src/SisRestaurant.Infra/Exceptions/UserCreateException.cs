using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisRestaurant.Infra.Exceptions
{
    public class UserCreateException : Exception
    {
        public IEnumerable<IdentityError> Errors { get; set; }

        public UserCreateException(IEnumerable<IdentityError> errors)
        {
            Errors = errors;
        }
    }
}
