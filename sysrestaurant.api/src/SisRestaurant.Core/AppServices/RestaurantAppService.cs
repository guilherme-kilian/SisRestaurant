using AutoMapper;
using AutoMapper.QueryableExtensions;
using SisRestaurant.Core.AppServices.Base;
using SisRestaurant.Infra.Domain;
using SisRestaurant.Infra.Repositories;
using SisRestaurant.Models.Restaurants;

namespace SisRestaurant.Core.AppServices;

public class RestaurantAppService : BaseAppService, IAppService<CreateRestaurantModel, UpdateRestaurantModel, RestaurantModel, int>
{
    public RestaurantAppService(SisRestaurantContext db, IMapper mapper) : base(db, mapper)
    {
    }

    public Task<RestaurantModel> Create(CreateRestaurantModel create)
    {
        throw new NotImplementedException();
    }

    public Task<RestaurantModel> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<RestaurantModel> Get(int id)
    {
        return Db.Restaurants
            .GetById(id)
            .ProjectTo<RestaurantModel>(Mapper.ConfigurationProvider)
            .FirstOrErrorAsync();
    }

    public Task<RestaurantModel> Update(UpdateRestaurantModel create)
    {
        throw new NotImplementedException();
    }
}
