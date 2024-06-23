using Microsoft.AspNetCore.Identity;

namespace SisRestaurant.Infra.Exceptions;

public class UserCreateException : Exception
{
    public IEnumerable<IdentityError> Errors { get; set; }

    public UserCreateException(IEnumerable<IdentityError> errors)
    {
        Errors = errors;
    }
}
