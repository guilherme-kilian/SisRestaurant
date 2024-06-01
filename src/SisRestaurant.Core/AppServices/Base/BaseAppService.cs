using SisRestaurant.Infra.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisRestaurant.Core.AppServices.Base;

public abstract class BaseAppService
{
    protected readonly SisRestaurantContext Db;

    protected BaseAppService(SisRestaurantContext db)
    {
        Db = db;
    }
}
