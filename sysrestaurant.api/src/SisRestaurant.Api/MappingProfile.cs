﻿using AutoMapper;
using SisRestaurant.Infra.Domain.Menus;
using SisRestaurant.Infra.Domain.Reservations;
using SisRestaurant.Infra.Domain.Restaurants;
using SisRestaurant.Infra.Domain.Users;
using SisRestaurant.Models.MenuItems;
using SisRestaurant.Models.Menus;
using SisRestaurant.Models.Reservations;
using SisRestaurant.Models.ReservationSettings;
using SisRestaurant.Models.Restaurants;
using SisRestaurant.Models.Users;

namespace SisRestaurant.Api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Restaurant, RestaurantModel>();
        CreateMap<User, UserModel>();
        CreateMap<MenuItem, MenuItemModel>();
        CreateMap<Menu, MenuModel>();
        CreateMap<Reservation, ReservationModel>();
        CreateMap<ReservationSettings, ReservationSettingsModel>();
        CreateMap<Restaurant, ShortRestaurantModel>();
    }
}
