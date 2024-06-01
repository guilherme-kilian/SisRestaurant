using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisRestaurant.Infra.Domain.Shared;

public class SoftDelete : Entity
{
    public bool Deleted { get; set; }
    public DateTime DeletedAt { get; set; }

    public void Delete()
    {
        Deleted = true;
        DeletedAt = DateTime.UtcNow;
    }
}
