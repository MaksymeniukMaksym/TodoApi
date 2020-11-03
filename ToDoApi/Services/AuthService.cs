using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ToDoApi.Interfaces;
using ToDoApi.Models;

namespace ToDoApi.Services
{
    public class AuthService : IAuthService
    {
        private List<UserViewModel> _users = new List<UserViewModel> {
            new UserViewModel {
                Id = 1,
                Name = "test",
                Surname = "test",
                Email = "test0@test.com",
                Password = "test",
            },
            new UserViewModel {
                Id = 2,
                Name = "test",
                Surname = "test",
                Email = "test1@test.com",
                Password = "test",
        }
        };
        public LoginResponse Login(LoginData Data)
        {
            var identity = GetIdentity(Data);
            if (identity == null)
            {
                return null;
            }
            var now = DateTime.UtcNow;
      
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                Issuer = AuthOptions.ISSUER,
                Audience = AuthOptions.AUDIENCE,
                SigningCredentials = new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encodedJwt = tokenHandler.WriteToken(token);


            var response = new LoginResponse
            {
                Token = encodedJwt,
                Name = identity.Name
            };

            return response;
        }
       public void Register(RegisterData data)
        {
            throw new NotImplementedException();
        }

    private ClaimsIdentity GetIdentity(LoginData Data)
        {
            UserViewModel user = _users.FirstOrDefault(user => user.Email == Data.Email && user.Password == Data.Password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Name),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, "user"),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())

                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }
    }
}
