using AutoMapper;
using SisRestaurant.Core.AppServices.Base;
using SisRestaurant.Infra.Domain;
using SisRestaurant.Models.Reservations;
using SisRestaurant.Infra.Repositories;
using AutoMapper.QueryableExtensions;

namespace SisRestaurant.Core.AppServices
{
    public class ReservationAppService : BaseAppService, IAppService<CreateReservationModel, ReservationModel, int>
    {
        public ReservationAppService(SisRestaurantContext db, IMapper mapper) : base(db, mapper)
        {
        }

        public async Task<ReservationModel> Create(string userId, CreateReservationModel create)
        {
            var user = await Db.Users.GetUserWithRestaurant(userId, create.RestaurantId);

            var restaurant = user.GetRestaurant(create.RestaurantId);

            var reservation = restaurant.Reserve(create.Date, user, create.Count, details: create.Details);

            return Mapper.Map<ReservationModel>(reservation);
        }

        public Task<ReservationModel> Get(int id)
        {
            return Db.Reservations
                .GetById(id)
                .ProjectTo<ReservationModel>(Mapper.ConfigurationProvider)
                .FirstOrErrorAsync();
        }
    }
}
