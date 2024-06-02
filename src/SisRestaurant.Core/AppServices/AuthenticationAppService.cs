using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SisRestaurant.Core.AppServices.Base;
using SisRestaurant.Infra.Domain;
using SisRestaurant.Infra.Domain.Users;
using SisRestaurant.Infra.Exceptions;
using SisRestaurant.Models;
using SisRestaurant.Models.Authentications;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SisRestaurant.Core.AppServices
{
    public class AuthenticationAppService : BaseAppService
    {
        private readonly AppSettings _appSettings;
        private readonly UserManager<User> _userManager;

        public AuthenticationAppService(UserManager<User> userManager, SisRestaurantContext db, IMapper mapper, IOptions<AppSettings> options) : base(db, mapper)
        {
            _appSettings = options.Value;
            _userManager = userManager;
        }

        public async Task<AuthModel> SignInAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if(user is null)
                throw new DataNotFoundException(nameof(user));

            if (!await _userManager.CheckPasswordAsync(user, password))
                throw new InvalidOperationException("User or password invalid");

            ArgumentNullException.ThrowIfNull(user.UserName);
            return GenerateAuthorizationToken(user.Id, user.UserName);            
        }

        private AuthModel GenerateAuthorizationToken(string userId, string userName)
        {
            var now = DateTime.UtcNow;
            var secret = _appSettings.Secret;
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));

            var userClaims = new List<Claim>{new (ClaimsIdentity.DefaultNameClaimType, userName), new (ClaimTypes.NameIdentifier, userId) };

            //userClaims.AddRange(roles.Select(r => new Claim(ClaimsIdentity.DefaultRoleClaimType, r)));

            var expires = now.Add(TimeSpan.FromMinutes(60));

            var jwt = new JwtSecurityToken(
                    notBefore: now,
                    claims: userClaims,
                    expires: expires,
                    audience: "https://localhost:7000/",
                    issuer: "https://localhost:7000/",
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var resp = new AuthModel
            {
                UserId = userId,
                AuthorizationToken = encodedJwt,
                RefreshToken = string.Empty
            };

            return resp;
        }
    }
}
