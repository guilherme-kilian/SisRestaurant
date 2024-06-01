using SisRestaurant.Infra.Domain.Categories;
using SisRestaurant.Infra.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisRestaurant.Infra.Domain.Menus;

public class MenuItem : SoftDelete
{
    public required string Name { get; set; }

    [Range(0, double.MaxValue)]
    public double Price { get; set; }

    public required Category Category { get; set; }
}
