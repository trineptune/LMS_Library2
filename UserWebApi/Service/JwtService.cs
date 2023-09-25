using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Microsoft.Exchange.WebServices.Data;
using UserWebApi.Models;
using Microsoft.EntityFrameworkCore;
using UserWebApi.Data;

namespace UserWebApi.Service
{
    public class JwtService
    {
        private readonly IConfiguration _configuration;
        private readonly UserDbContext _context;
        public JwtService(IConfiguration configuration,UserDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        internal static Task<bool> ValidateUserRole(UserId userId, string v)
        {
            throw new NotImplementedException();
        }

        public string GenerateToken(User user)
        {
            var claims = new[]
     {
        new Claim(ClaimTypes.Email, user.Email
        )
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var roleName = _context.Roles
                .Where(r => r.Id == user.RoleId)
                .Select(r => r.RoleName)
                .FirstOrDefault();

            if (!string.IsNullOrEmpty(roleName))
            {
                var roleClaim = new Claim(ClaimTypes.Role, roleName);
                claims = claims.Concat(new[] { roleClaim }).ToArray();
            }

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );
           
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
