using Microsoft.AspNetCore.Mvc;
using SisRestaurant.Core.AppServices;
using SisRestaurant.Models.MenuItems;

namespace SisRestaurant.Api.Controllers
{
    [ApiController]
    [Route("api/v1/menu/{menuId}/[controller]")]
    public class MenuItemController : ControllerBase
    {
        private readonly MenuItemAppService _menuItemAppService;

        public MenuItemController(MenuItemAppService menuItemAppService)
        {
            _menuItemAppService = menuItemAppService;
        }

        [HttpPost]
        public Task<MenuItemModel> AddItem(int menuId, CreateMenuItemModel create)
        {
            return _menuItemAppService.AddItem(menuId, create);
        }

        [HttpDelete("{menuItemId}")]
        public Task<MenuItemModel> RemoveItem(int menuId, int menuItemId)
        {
            return _menuItemAppService.RemoveItem(menuId, menuItemId);
        }
    }
}
