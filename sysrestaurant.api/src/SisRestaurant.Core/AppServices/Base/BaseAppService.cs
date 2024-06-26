﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SisRestaurant.Infra.Domain;
using SisRestaurant.Infra.Domain.Users;

namespace SisRestaurant.Core.AppServices.Base;

public abstract class BaseAppService
{
    protected readonly SisRestaurantContext Db;
    protected readonly IMapper Mapper;

    protected BaseAppService(SisRestaurantContext db, IMapper mapper)
    {
        Db = db;
        Mapper = mapper;
    }
}
