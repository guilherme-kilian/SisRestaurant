using AutoMapper;
using SisRestaurant.Core.AppServices.Base;
using SisRestaurant.Infra.Domain;
using SisRestaurant.Infra.Domain.Categories;
using SisRestaurant.Infra.Domain.Menus;
using SisRestaurant.Models.MenuItems;
using SisRestaurant.Infra.Repositories;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace SisRestaurant.Core.AppServices
{
    public class MenuItemAppService : BaseAppService, IBasicAppService<MenuItemModel, int>
    {
        public MenuItemAppService(SisRestaurantContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public async Task<MenuItem> Create(CreateMenuItemModel create)
        {
            var category = await Db.Categories.GetByName(create.CategoryName);

            if (category is null)
            {
                category = new Category(create.CategoryName);
                Db.Categories.Add(category);
            }

            var item = new MenuItem(create.Name, create.Price, create.Product, category);

            Db.MenuItems.Add(item);

            return item;
        }

        public Task<MenuItemModel> Get(int id)
        {
            return Db.MenuItems
                .GetById(id)
                .ProjectTo<MenuItemModel>(Mapper.ConfigurationProvider)
                .FirstOrErrorAsync();
        }

        public Task<MenuItemModel> Get(int menuId, int id)
        {
            return Db.MenuItems
                .OfMenu(menuId)
                .GetById(id)
                .ProjectTo<MenuItemModel>(Mapper.ConfigurationProvider)
                .FirstOrErrorAsync();
        }


        public async Task<MenuItemModel> AddItem(int menuId, CreateMenuItemModel create)
        {
            var menu = await Db.Menus
                .IncludeItems()
                .GetFirstByIdOrError(menuId);

            if(menu.Items.Any(i => i.Product == create.Product))
                throw new InvalidOperationException(string.Format("Item {0} already exists in menu", create.Product));
            
            var item = await Create(create);

            menu.AddItem(item);

            await Db.SaveChangesAsync();

            return Mapper.Map<MenuItemModel>(item);
        }

        public async Task<MenuItemModel> RemoveItem(int menuId, int menuItemId)
        {
            var menu = await Db.Menus
                .IncludeItems()
                .GetFirstByIdOrError(menuId);

            if (!menu.Items.Any(i => i.Id == menuItemId && !i.Deleted))
                throw new InvalidOperationException("ItemNotFoundToBeDeleted");

            var menuItem = menu.Items.First(i => i.Id == menuItemId);

            menu.RemoveItem(menuItem);

            await Db.SaveChangesAsync();

            return Mapper.Map<MenuItemModel>(menuItem);
        }
    }
}
