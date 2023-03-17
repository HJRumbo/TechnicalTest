using Dtos;
using Domain.Common;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JsonWebTokenService
{
    public class TokenService : ITokenService
    {
        private readonly AppSetting _appSettings;

        public TokenService(IOptions<AppSetting> appSettings) => _appSettings = appSettings.Value;

        public LoginViewDto GenerateToken(LoginInputDto login)
        {
            // return null if user not found
            if (login == null) return null!;

            var response = new LoginViewDto() { UserName = login.UserName };

            // authentication successful so generate jwt token

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("userName", login.UserName!.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            response.Token = tokenHandler.WriteToken(token);
            return response;
        }
    }
}