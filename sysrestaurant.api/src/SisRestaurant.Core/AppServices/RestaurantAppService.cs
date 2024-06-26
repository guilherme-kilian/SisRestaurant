using AutoMapper;
using AutoMapper.QueryableExtensions;
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

    public async Task<RestaurantModel> Delete(int id)
    {
        var restaurant = await Db.Restaurants.GetFirstByIdOrError(id);

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

    public Task<RestaurantModel> Get(int id)
    {
        return Db.Restaurants
            .GetById(id)
            .ProjectTo<RestaurantModel>(Mapper.ConfigurationProvider)
            .FirstOrErrorAsync();
    }
}
