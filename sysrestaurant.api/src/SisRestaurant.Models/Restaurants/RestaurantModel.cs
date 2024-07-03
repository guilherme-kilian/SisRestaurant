using SisRestaurant.Models.Menus;
using SisRestaurant.Models.Reservations;
using SisRestaurant.Models.ReservationSettings;
using SisRestaurant.Models.Users;

namespace SisRestaurant.Models.Restaurants;

public class RestaurantModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required List<MenuModel> Menus { get; set; }
    public required ReservationSettingsModel Settings { get; set; }
    public List<ReservationModel> Reservations { get; set; } = [];
    public required List<UserModel> Users { get; set; }
    public bool Open { get; set; }
}
