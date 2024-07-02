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
        public Task Post(CreateMenuModel create) => _menuAppService.Create(User.GetUserId(), create);

        [HttpGet("{menuId}")]
        public Task Get(int menuId) => _menuAppService.Get(menuId);
    }
}
