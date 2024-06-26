using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisRestaurant.Core.AppServices;
using SisRestaurant.Models.Authentications;

namespace SisRestaurant.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly AuthenticationAppService _authAppService;

    public AuthenticationController(AuthenticationAppService authAppService)
    {
        _authAppService = authAppService;
    }

    [AllowAnonymous]
    [HttpPost]
    public Task<AuthResponseModel> Login(AuthRequestModel model) =>
        _authAppService.SignInAsync(model.Email, model.Password);
}
