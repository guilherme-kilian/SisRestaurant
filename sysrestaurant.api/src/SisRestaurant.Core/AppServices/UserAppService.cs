using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SisRestaurant.Core.AppServices.Base;
using SisRestaurant.Infra.Domain;
using SisRestaurant.Infra.Domain.Users;
using SisRestaurant.Infra.Exceptions;
using SisRestaurant.Models.Users;

namespace SisRestaurant.Core.AppServices;

public class UserAppService : BaseAppService, IAppService<CreateUserModel, UserModel, string>
{
    private readonly UserManager<User> _userManager;

    public UserAppService(SisRestaurantContext db, UserManager<User> userManager, IMapper mapper) : base(db, mapper)
    {
        _userManager = userManager;
    }

    public async Task<UserModel> Create(string userId, CreateUserModel create)
    {
        var user = new User(create.FullName, create.UserName, create.Email);
        var result = await _userManager.CreateAsync(user, create.Password);

        if (!result.Succeeded)
        {
            throw new UserCreateException(result.Errors);
        }

        return Mapper.Map<UserModel>(user);
    }

    public async Task<UserModel> Get(string id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());

        if (user is null)
            throw new DataNotFoundException(nameof(user));

        return Mapper.Map<UserModel>(user);
    }
}
