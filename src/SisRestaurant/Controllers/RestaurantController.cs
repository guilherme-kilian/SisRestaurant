using Microsoft.AspNetCore.Mvc;
using SisRestaurant.Core.AppServices;
using SisRestaurant.Models.Restaurants;

namespace SisRestaurant.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RestaurantController : ControllerBase
{
    private readonly RestaurantAppService _restaurantAppService;
    private readonly ILogger<RestaurantController> _logger;

    public RestaurantController(RestaurantAppService restaurantAppService, ILogger<RestaurantController> logger)
    {
        _restaurantAppService = restaurantAppService;
        _logger = logger;
    }

    [HttpPost]
    public Task<RestaurantModel> Create(CreateRestaurantModel create)
    {
        return _restaurantAppService.Create(create);
    }

    [HttpGet]
    public Task<RestaurantModel> Get(int id)
    {
        return _restaurantAppService.Get(id);
    }
}
