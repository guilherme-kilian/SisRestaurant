namespace SisRestaurant.Core.AppServices.Base;

public interface IAppService<TCreate, TUpdate, TGet>
{
    Task<TGet> Create(TCreate create);
    Task<TGet> Update(TUpdate create);
    Task<TGet> Get(int id);
    Task<TGet> Delete(int id);
}
