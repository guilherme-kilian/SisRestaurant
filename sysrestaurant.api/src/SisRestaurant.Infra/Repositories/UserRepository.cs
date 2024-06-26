﻿using Microsoft.EntityFrameworkCore;
using SisRestaurant.Infra.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisRestaurant.Infra.Repositories
{
    public static class UserRepository
    {
        public static Task<User> GetById(this IQueryable<User> query, string userId) => query.Where(i => i.Id == userId).FirstOrErrorAsync();

        public static async Task<User> GetUserWithRestaurant(this IQueryable<User> query, string userId, int restaurantId)
        {
            var user = await query
                .Include(r => r.Restaurants)
                .GetById(userId);

            if (!user.HasPermission(restaurantId))
                throw new InvalidOperationException("UserDoesNotHavePermission");

            return user;
        }
    }
}
