using SisRestaurant.Infra.Domain.Restaurants;

namespace SisRestaurant.Infra.Repositories
{
    public static class RestaurantRepository
    {
        public static IQueryable<Restaurant> GetByName(this IQueryable<Restaurant> query, string name)
        {
            return query.Where(r => r.Name == name);
        }
    }
}
