using Microsoft.EntityFrameworkCore;
using SisRestaurant.Infra.Domain.Shared;
using SisRestaurant.Infra.Exceptions;

namespace SisRestaurant.Infra.Repositories;

public static class EntityRepository
{
    public static IQueryable<T> GetById<T>(this IQueryable<T> entity, int id) where T : Entity => entity.Where(entity => entity.Id == id);

    public static IQueryable<T> Active<T>(this IQueryable<T> entity) where T : SoftDelete => entity.Where(entity => !entity.Deleted);

    public static async Task<T> FirstOrErrorAsync<T>(this IQueryable<T> entity, string? message = null) => 
        await entity.FirstOrDefaultAsync() ?? throw new DataNotFoundException(message ?? $"{nameof(T)}");
}
