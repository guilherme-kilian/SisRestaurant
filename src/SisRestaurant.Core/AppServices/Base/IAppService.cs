namespace SisRestaurant.Core.AppServices.Base;

public interface IAppService<TCreate, TUpdate, TGet, TID>
{
    Task<TGet> Create(TCreate create);
    Task<TGet> Update(TUpdate create);
    Task<TGet> Get(TID id);
    Task<TGet> Delete(TID id);
}
