using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisRestaurant.Core.AppServices.Base
{
    public interface IBasicAppService<TGet, TID>
    {
        Task<TGet> Get(TID id);
    }
}
