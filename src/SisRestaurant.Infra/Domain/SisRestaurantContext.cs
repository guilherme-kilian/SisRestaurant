using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SisRestaurant.Infra.Domain.Categories;
using SisRestaurant.Infra.Domain.Menus;
using SisRestaurant.Infra.Domain.Notifications;
using SisRestaurant.Infra.Domain.Payments;
using SisRestaurant.Infra.Domain.Reservations;
using SisRestaurant.Infra.Domain.Restaurants;
using SisRestaurant.Infra.Domain.Users;
namespace SisRestaurant.Infra.Domain;

public class SisRestaurantContext : IdentityDbContext<User>
{
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<ReservationSettings> ReservationSettings { get; set; }
    public DbSet<Category> Categories{ get; set; }
    public DbSet<Notification> Notifications { get; set; }

    public SisRestaurantContext(DbContextOptions options) : base(options)
    {
    }
}
