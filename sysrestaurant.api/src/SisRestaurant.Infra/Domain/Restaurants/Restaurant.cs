﻿using SisRestaurant.Infra.Domain.Menus;
using SisRestaurant.Infra.Domain.Reservations;
using SisRestaurant.Infra.Domain.Shared;
using SisRestaurant.Infra.Domain.Users;
using System.ComponentModel.DataAnnotations;

namespace SisRestaurant.Infra.Domain.Restaurants;

public class Restaurant : SoftDelete
{
    [Required]
    public string Name { get; private set; }

    [Required]
    public string Email { get; private set; }
    
    [Required]
    public string PhoneNumber { get; private set; }

    [Required]
    public List<User> Users { get; private set; }

    public List<Menu> Menus { get; private set; } = [];

    public ReservationSettings Settings { get; private set; }        

    public bool Open { get; private set; }

    public List<Reservation> Reservations { get; private set; } = [];    

    protected Restaurant() { }

    public Restaurant(
        string name, 
        string email, 
        string phoneNumber,
        ReservationSettings settings, 
        User user)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);
        ArgumentException.ThrowIfNullOrWhiteSpace(phoneNumber);

        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        Settings = settings;
        Users = [user];
    }

    public void SetMenu(Menu menu)
    {
        Menus.Add(menu);
    }

    public Menu GetMenu(int menuId)
    {
        return Menus.First(i => i.Id == menuId && !i.Deleted);
    }
}
