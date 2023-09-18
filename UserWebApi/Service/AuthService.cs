using UserWebApi.Data;
using UserWebApi.Models;

namespace UserWebApi.Service
{
    public class AuthService
    {
        private readonly UserDbContext _context;
        private readonly JwtService _jwtService;

        public AuthService(UserDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public string Authenticate(string Email, string password,string role)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == Email && u.Password == password && u.role.RoleName == role);

            if (user != null)
            {
                return _jwtService.GenerateToken(Email, role);
            }

            return null;
        }
    }
}
