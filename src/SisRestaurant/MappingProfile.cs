using AutoMapper;
using SisRestaurant.Infra.Domain.Restaurants;
using SisRestaurant.Models.Restaurants;

namespace SisRestaurant.Api
{
    public class MappingProfile : Profile
    {
        protected MappingProfile()
        {
            CreateMap<Restaurant, RestaurantModel>();
        }
    }
}
