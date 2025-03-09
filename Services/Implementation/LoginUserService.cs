using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatorR.App;
using MediatorR.Data;
using MediatorR.Dtos;
using MediatorR.Models;
using MediatorR.Services.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;

namespace MediatorR.Services.Implementation
{
    public class LoginUserService : ILoginUserService
    {
        private readonly UserDbContext _context;
        private readonly IConfiguration _jwtSetting;

        public LoginUserService(UserDbContext context,IConfiguration jwtSetting)
        {
            _context = context;
            _jwtSetting = jwtSetting;
        }

        public Task<string> LoginUser(LoginDto loginDto)
        {
            var user = _context.tblUserProfiles.FirstOrDefault(x => x.Email == loginDto.Email);

            if(user == null || !PasswordHash.VerifyPassword(loginDto.Password , user.Password))
            {
                throw new Exception("Invalid Credintals");
            }

            var token = GenerateJwtToken(user.UserName);
            return Task.FromResult(token);
        }

        private string GenerateJwtToken(string username)
        {
            var issuer = _jwtSetting["JwtSettings:Issuer"];
            var audience = _jwtSetting["JwtSettings:Audience"];
            var key = Encoding.UTF8.GetBytes(_jwtSetting["JwtSettings:Key"]);
            var expirationInMinutes = int.Parse(_jwtSetting["JwtSettings:ExpirationInMinutes"]);

            var authClaim = new[]
             {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier , username),
             };

            var token = new JwtSecurityToken
                (
                issuer,
                audience,
                authClaim,
                expires: DateTime.UtcNow.AddMinutes(expirationInMinutes),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
