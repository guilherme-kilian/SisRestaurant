using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisRestaurant.Infra.Domain.Shared
{
    public interface ISoftDelete
    {
        bool Deleted { get; }
        DateTime DeletedAt { get; }
        void Delete();
    }
}
