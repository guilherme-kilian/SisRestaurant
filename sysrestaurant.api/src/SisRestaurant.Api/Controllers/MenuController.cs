using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisRestaurant.Core.AppServices;
using SisRestaurant.Core.Extensions;
using SisRestaurant.Models.Menus;

namespace SisRestaurant.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly MenuAppService _menuAppService;

        public MenuController(MenuAppService menuAppService)
        {
            _menuAppService = menuAppService;
        } 

        [HttpPost]
        public Task<MenuModel> Post(CreateMenuModel create) => _menuAppService.Create(User.GetUserId(), create);

        [HttpGet("{id}")]
        public Task<MenuModel> Get(int id) => _menuAppService.Get(id);

        [HttpDelete("{id}")]
        public Task<MenuModel> Delete(int id) => _menuAppService.Delete(User.GetUserId(), id);
    }
}
