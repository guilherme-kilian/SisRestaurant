namespace SisRestaurant.Infra.Exceptions;

public class DataNotFoundException : Exception
{
    public DataNotFoundException(string? message) : base(message)
    {
    }
}
