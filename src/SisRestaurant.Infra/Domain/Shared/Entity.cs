using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisRestaurant.Infra.Domain.Shared;

public class Entity
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public Entity()
    {
        CreatedAt = DateTime.Now;
    }
}
