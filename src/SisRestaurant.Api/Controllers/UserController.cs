using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisRestaurant.Core.AppServices;
using SisRestaurant.Core.Extensions;
using SisRestaurant.Models.Users;

namespace SisRestaurant.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserAppService _userAppService;

    public UserController(UserAppService userAppService)
    {
        _userAppService = userAppService;
    }

    [HttpPost]
    [AllowAnonymous]
    public Task<UserModel> Create(CreateUserModel create) => _userAppService.Create(create);

    [HttpGet]
    public Task<UserModel> Get() => _userAppService.Get(User.GetUserId());
}
