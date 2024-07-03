using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SisRestaurant.Core.AppServices.Base;
using SisRestaurant.Infra.Domain;
using SisRestaurant.Infra.Domain.Reservations;
using SisRestaurant.Infra.Domain.Restaurants;
using SisRestaurant.Infra.Repositories;
using SisRestaurant.Models.Restaurants;

namespace SisRestaurant.Core.AppServices;

public class RestaurantAppService : BaseAppService, IAppService<CreateRestaurantModel, RestaurantModel, int>
{
    public RestaurantAppService(SisRestaurantContext db, IMapper mapper) : base(db, mapper)
    {
    }

    public async Task<RestaurantModel> Create(string userId, CreateRestaurantModel create)
    {
        var user = await Db.Users.GetById(userId);

        var settings = new ReservationSettings(
            create.Settings.PaymentRequired, 
            create.Settings.StartAt, 
            create.Settings.FinishAt, 
            create.Settings.Capacity);

        var restaurant = new Restaurant(create.Name, create.Email, create.PhoneNumber, settings, user);

        Db.Restaurants.Add(restaurant);

        await Db.SaveChangesAsync();

        return Mapper.Map<RestaurantModel>(restaurant);
    }

    public async Task<RestaurantModel> Delete(string userId, int id)
    {
        var user = await Db.Users.GetUserWithRestaurant(userId, id);

        var restaurant = user.GetRestaurant(id);

        restaurant.Delete();
        
        if(restaurant.Menus is not null)
        {
            foreach (var menu in restaurant.Menus)
            {
                menu.Delete();

                foreach (var item in menu.Items)
                    item.Delete();
            }
        }

        await Db.SaveChangesAsync();

        return Mapper.Map<RestaurantModel>(restaurant);
    }

    public Task<List<ShortRestaurantModel>> Filter(FilterRestaurantModel filter)
    {
        var query = Db.Restaurants.Active();

        if (!string.IsNullOrEmpty(filter.Name))
            query = query.ContainsName(filter.Name);

        if(filter.Open.HasValue)
            query = query.Where(q => q.Open == filter.Open.Value);

        if(filter.Category != null && filter.Category.Count != 0)
            query = query.HasItemInCategory(filter.Category);

        return query
            .Skip(filter.Skip)
            .Take(filter.Take)
            .ProjectTo<ShortRestaurantModel>(Mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public Task<RestaurantModel> Get(int id)
    {
        return Db.Restaurants
            .GetById(id)
            .ProjectTo<RestaurantModel>(Mapper.ConfigurationProvider)
            .FirstOrErrorAsync();
    }

    public Task<List<RestaurantModel>> GetAll(string userId)
    {
        return Db.Restaurants
            .GetByUser(userId)
            .ProjectTo<RestaurantModel>(Mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<RestaurantModel> Update(string userId, int restaurantId, UpdateRestaurantModel update)
    {
        var user = await Db.Users.GetUserWithRestaurant(userId, restaurantId);

        var restaurant = user.GetRestaurant(restaurantId);

        if (update.Open.HasValue)
            restaurant.SetOpen(update.Open.Value);

        await Db.SaveChangesAsync();

        return Mapper.Map<RestaurantModel>(restaurant);
    }
}
