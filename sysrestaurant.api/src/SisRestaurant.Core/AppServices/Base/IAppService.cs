namespace SisRestaurant.Core.AppServices.Base;

public interface IAppService<TCreate, TGet, TID> : IBasicAppService<TGet, TID>
{
    Task<TGet> Create(string userId, TCreate create);
}
