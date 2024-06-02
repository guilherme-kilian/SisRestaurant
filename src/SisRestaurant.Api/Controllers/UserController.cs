using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisRestaurant.Core.AppServices;
using SisRestaurant.Models.Authentications;
using SisRestaurant.Models.Users;

namespace SisRestaurant.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserAppService _userAppService;
        private readonly AuthenticationAppService _authAppService;

        public UserController(UserAppService userAppService, AuthenticationAppService authAppService)
        {
            _userAppService = userAppService;
            _authAppService = authAppService;
        }

        [HttpPost]
        [AllowAnonymous]
        public Task<UserModel> Create(CreateUserModel create) => _userAppService.Create(create);

        [HttpGet("login")]
        public Task<AuthModel> Login(string email, string password) => 
            _authAppService.SignInAsync(email, password);
    }
}
