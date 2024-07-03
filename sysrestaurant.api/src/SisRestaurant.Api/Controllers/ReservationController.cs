using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SisRestaurant.Core.AppServices;
using SisRestaurant.Core.Extensions;
using SisRestaurant.Models.Reservations;

namespace SisRestaurant.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationAppService _reservationAppService;

        public ReservationController(ReservationAppService reservationAppService)
        {
            _reservationAppService = reservationAppService;
        }

        [HttpPost]
        public Task<ReservationModel> Create(CreateReservationModel create) => 
            _reservationAppService.Create(User.GetUserId(), create);

        [HttpGet("{id}")]
        public Task<ReservationModel> Get(int id) => 
            _reservationAppService.Get(id);

        [HttpDelete("{id}")]
        public Task<ReservationModel> Delete(int id) =>
            _reservationAppService.Delete(User.GetUserId(), id);
    }
}
