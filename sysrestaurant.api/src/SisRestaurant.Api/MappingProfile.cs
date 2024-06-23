using AutoMapper;
using SisRestaurant.Infra.Domain.Restaurants;
using SisRestaurant.Infra.Domain.Users;
using SisRestaurant.Models.Restaurants;
using SisRestaurant.Models.Users;

namespace SisRestaurant.Api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Restaurant, RestaurantModel>();
        CreateMap<User, UserModel>();
    }
}
