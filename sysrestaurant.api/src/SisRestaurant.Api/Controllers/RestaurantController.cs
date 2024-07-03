using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisRestaurant.Core.AppServices;
using SisRestaurant.Core.Extensions;
using SisRestaurant.Models.Restaurants;

namespace SisRestaurant.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
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
    public Task<RestaurantModel> Post([FromBody] CreateRestaurantModel create)
    {
        return _restaurantAppService.Create(User.GetUserId(), create);
    }

    [HttpGet]
    public Task<List<RestaurantModel>> GetAll()
    {
        return _restaurantAppService.GetAll(User.GetUserId());
    }

    [HttpGet("{id}")]
    public Task<RestaurantModel> Get(int id)
    {
        return _restaurantAppService.Get(id);
    }

    [HttpPut("{id}")]
    public Task<RestaurantModel> Put(int id, UpdateRestaurantModel update)
    {
        return _restaurantAppService.Update(User.GetUserId(), id, update);
    }

    [HttpDelete("{id}")]
    public Task<RestaurantModel> Delete(int id)
    {
        return _restaurantAppService.Delete(User.GetUserId(), id);
    }

    [HttpGet("filter")]
    public Task<List<ShortRestaurantModel>> Filter([FromQuery] FilterRestaurantModel filter)
    {
        return _restaurantAppService.Filter(filter);
    }
}
