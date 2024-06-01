using SisRestaurant.Infra.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisRestaurant.Infra.Domain.Users;

public class User : SoftDelete
{
    public required string Name { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}
