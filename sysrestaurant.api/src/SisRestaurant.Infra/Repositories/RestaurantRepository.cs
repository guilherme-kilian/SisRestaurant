using Microsoft.EntityFrameworkCore;
using SisRestaurant.Infra.Domain.Restaurants;

namespace SisRestaurant.Infra.Repositories;

public static class RestaurantRepository
{
    public static IQueryable<Restaurant> GetByName(this IQueryable<Restaurant> query, string name)
    {
        return query.Where(r => r.Name == name);
    }

    public static IQueryable<Restaurant> GetByUser(this IQueryable<Restaurant> query, string userId)
    {
        return query.Active().Where(r => r.Users.Any(u => u.Id == userId));
    }

    public static IQueryable<Restaurant> ContainsName(this IQueryable<Restaurant> query, string name)
    {
        return query.Where(r => r.Name.Contains(name));
    }

    public static IQueryable<Restaurant> HasItemInCategory(this IQueryable<Restaurant> query, List<string> categories)
    {
        return query.Where(q => q.Menus.Any(m => m.Items.Any(mi => categories.Contains(mi.Category.Name))));
    }

    public static IQueryable<Restaurant> IncludeSettings(this IQueryable<Restaurant> query)
    {
        return query.Include(q => q.Settings);
    }
}
