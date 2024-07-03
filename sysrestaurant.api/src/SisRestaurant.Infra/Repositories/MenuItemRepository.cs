using SisRestaurant.Infra.Domain.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisRestaurant.Infra.Repositories
{
    public static class MenuItemRepository
    {
        public static IQueryable<MenuItem> OfMenu(this IQueryable<MenuItem> query, int menuId) => 
            query.Where(q => q.Menu.Id == menuId);
    }
}
