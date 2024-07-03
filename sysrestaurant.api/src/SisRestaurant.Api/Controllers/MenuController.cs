using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisRestaurant.Core.AppServices;
using SisRestaurant.Core.Extensions;
using SisRestaurant.Models.Menus;

namespace SisRestaurant.Api.Controllers
{
    [ApiController]
    [Route("api/v1/Restaurant/{restaurantId}/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly MenuAppService _menuAppService;

        public MenuController(MenuAppService menuAppService)
        {
            _menuAppService = menuAppService;
        } 

        [HttpPost]
        public Task<MenuModel> Post(int restaurantId, CreateMenuModel create) => _menuAppService.Create(User.GetUserId(), restaurantId, create);

        [HttpGet("{id}")]
        public Task<MenuModel> Get(int restaurantId, int id) => _menuAppService.Get(id);

        [HttpDelete("{id}")]
        public Task<MenuModel> Delete(int restaurantId, int id) => _menuAppService.Delete(User.GetUserId(), restaurantId, id);
    }
}
