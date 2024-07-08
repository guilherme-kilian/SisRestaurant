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
            var restaurant = await Db.Restaurants
                .IncludeSettings()
                .GetById(create.RestaurantId).FirstOrErrorAsync();

            var user = await Db.Users.GetById(userId);

            var reservation = restaurant.Reserve(create.Date, user, create.Count, details: create.Details);

            await Db.SaveChangesAsync();

            return Mapper.Map<ReservationModel>(reservation);
        }

        public Task<ReservationModel> Get(int id)
        {
            return Db.Reservations
                .GetById(id)
                .ProjectTo<ReservationModel>(Mapper.ConfigurationProvider)
                .FirstOrErrorAsync();
        }

        public async Task<ReservationModel> Delete(string userId, int id)
        {
            var user = await Db.Users.GetUserWithReservations(userId, id);

            var reservation = user.GetReservation(id);

            reservation.Delete();

            await Db.SaveChangesAsync();

            return Mapper.Map<ReservationModel>(reservation);
        }
    }
}
