using SisRestaurant.Infra.Domain.Shared;

namespace SisRestaurant.Infra.Domain.Menus;

public class Menu : SoftDelete
{
    public required List<MenuItem> Items { get; set; }
}
