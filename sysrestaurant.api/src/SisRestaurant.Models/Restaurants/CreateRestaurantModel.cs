using SisRestaurant.Models.MenuItems;
using SisRestaurant.Models.ReservationSettings;
using System.ComponentModel.DataAnnotations;

namespace SisRestaurant.Models.Restaurants;

public class CreateRestaurantModel
{
    public required string Name { get; set; }
    
    [EmailAddress]
    public required string Email { get; set; }

    [Phone]
    public required string PhoneNumber { get; set; }
        
    public required CreateReservationSettingsModel Settings { get; set; }
}
