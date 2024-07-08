using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisRestaurant.Core.AppServices;
using SisRestaurant.Models.MenuItems;

namespace SisRestaurant.Api.Controllers
{
    [ApiController]
    [Route("api/v1/Menu/{menuId}/[controller]")]
    public class MenuItemController : ControllerBase
    {
        private readonly MenuItemAppService _menuItemAppService;

        public MenuItemController(MenuItemAppService menuItemAppService)
        {
            _menuItemAppService = menuItemAppService;
        }

        [HttpPost]
        public Task<MenuItemModel> AddItem(int menuId, [FromBody]CreateMenuItemModel create)
        {
            return _menuItemAppService.AddItem(menuId, create);
        }

        [HttpGet("{id}")]
        public Task<MenuItemModel> GetItem(int menuId, int id)
        {
            return _menuItemAppService.Get(menuId, id);
        }

        [HttpDelete("{id}")]
        public Task<MenuItemModel> RemoveItem(int menuId, int id)
        {
            return _menuItemAppService.RemoveItem(menuId, id);
        }
    }
}
