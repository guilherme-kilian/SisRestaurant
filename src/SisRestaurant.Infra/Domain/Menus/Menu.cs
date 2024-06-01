using SisRestaurant.Infra.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisRestaurant.Infra.Domain.Menus;

public class Menu : SoftDelete
{
    public required List<MenuItem> Items { get; set; }
}
