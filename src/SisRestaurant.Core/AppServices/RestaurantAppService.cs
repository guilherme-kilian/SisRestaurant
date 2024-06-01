using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using SisRestaurant.Core.AppServices.Base;
using SisRestaurant.Infra.Domain;
using SisRestaurant.Infra.Repositories;
using SisRestaurant.Models.Restaurant;
using SisRestaurant.Models.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisRestaurant.Core.AppServices;

public class RestaurantAppService : BaseAppService, IAppService<CreateRestaurantModel, UpdateRestaurantModel, RestaurantModel>
{
    private readonly IMapper _mapper;

    public RestaurantAppService(SisRestaurantContext db, IMapper mapper) : base(db)
    {
        _mapper = mapper;
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
            .ProjectTo<RestaurantModel>(_mapper.ConfigurationProvider)
            .FirstOrErrorAsync();
    }

    public Task<RestaurantModel> Update(UpdateRestaurantModel create)
    {
        throw new NotImplementedException();
    }
}
