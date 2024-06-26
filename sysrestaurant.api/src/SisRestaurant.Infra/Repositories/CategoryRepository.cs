using Microsoft.EntityFrameworkCore;
using SisRestaurant.Infra.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisRestaurant.Infra.Repositories
{
    public static class CategoryRepository
    {
        public static Task<Category?> GetByName(this IQueryable<Category> query, string name) => query.Where(i => i.Name == name).FirstOrDefaultAsync();
    }
}
