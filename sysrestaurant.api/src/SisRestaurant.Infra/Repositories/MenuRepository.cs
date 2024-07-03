using Microsoft.EntityFrameworkCore;
using SisRestaurant.Infra.Domain.Menus;

namespace SisRestaurant.Infra.Repositories
{
    public static class MenuRepository
    {
        public static IQueryable<Menu> IncludeItems(this IQueryable<Menu> query) => 
            query.Include(menu => menu.Items.Where(i => !i.Deleted));

        public static IQueryable<Menu> IncludeRestaurantAndUsers(this IQueryable<Menu> query) => 
            query.Include(menu => menu.Restaurant).ThenInclude(r => r.Users);
    }
}
