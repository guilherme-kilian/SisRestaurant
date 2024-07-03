using AutoMapper;
using SisRestaurant.Core.AppServices.Base;
using SisRestaurant.Infra.Domain;
using SisRestaurant.Infra.Domain.Menus;
using SisRestaurant.Models.Menus;
using SisRestaurant.Infra.Repositories;
using SisRestaurant.Infra.Domain.Categories;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using SisRestaurant.Infra.Domain.Users;

namespace SisRestaurant.Core.AppServices
{
    public class MenuAppService : BaseAppService, IAppService<CreateMenuModel, MenuModel, int>
    {
        private readonly MenuItemAppService _menuItemAppService;

        public MenuAppService(SisRestaurantContext db, IMapper mapper, MenuItemAppService menuItemAppService) : base(db, mapper)
        {
            _menuItemAppService = menuItemAppService;
        }

        public async Task<MenuModel> Create(string userId, int restaurantId, CreateMenuModel create)
        {
            var user = await Db.Users.GetUserWithRestaurant(userId, restaurantId);

            var menuItems = new List<MenuItem>();

            foreach (var item in create.Items)
                menuItems.Add(await _menuItemAppService.Create(item));

            var restaurant = user.Restaurants.First(r => r.Id == restaurantId);

            var menu = new Menu(create.Name, menuItems, restaurant);

            Db.Menus.Add(menu);

            await Db.SaveChangesAsync();

            return Mapper.Map<MenuModel>(menu);
        }

        public async Task<MenuModel> Delete(string userId, int restaurantId, int menuId)
        {
            var user = await Db.Users.GetUserWithRestaurant(userId, menuId);

            var restaurant = user.Restaurants.First(i => i.Id == restaurantId);

            var menu = restaurant.GetMenu(menuId) ?? throw new InvalidOperationException("MenuNotFound");

            menu.Delete();

            await Db.SaveChangesAsync();

            return Mapper.Map<MenuModel>(menu);
        }

        public Task<MenuModel> Get(int id)
        {
            return Db.Menus
                .GetById(id)
                .ProjectTo<MenuModel>(Mapper.ConfigurationProvider)
                .FirstOrErrorAsync();
        }
    }
}
