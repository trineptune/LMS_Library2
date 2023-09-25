using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using UserWebApi.Models;
using UserWebApi.Repository;
using UserWebApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using UserWebApi.Data;

namespace UserWebApi.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : Controller
    {

        private readonly AuthService _authService;
        private readonly IUser _repo;
        private readonly JwtService _jwtService;
        private IHttpContextAccessor httpContextAccessor;
        private readonly UserDbContext _context;
        private readonly IRefreshToken _refreshTokenService;
        public LoginController(AuthService authService,IUser repo, JwtService jwtService,UserDbContext context,IRefreshToken refreshToken)
        {
            _authService = authService;
            _repo = repo;
            _jwtService = jwtService;
            _context = context;
            _refreshTokenService= refreshToken;
        }

        [HttpPost]
        public IActionResult Login(LoginDTO request)
        {
            string token = _authService.Authenticate(request, HttpContext);

            if (token != null)
            {
                int userId = (int)HttpContext.Session.GetInt32("UserId");
                _refreshTokenService.SetRefreshToken(userId);
                var user = _context.Users.FirstOrDefault(u => u.Id == userId);
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = user.TokenExpires
                };
                Response.Cookies.Append("refreshToken", user.RefreshToken, cookieOptions);

                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid credentials");
        }
        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            int userId = (int)HttpContext.Session.GetInt32("UserId");

            // Kiểm tra xem người dùng đã đăng xuất hay chưa
            if (userId == 0)
            {
                return Unauthorized("User is logged out.");
            }

            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (!user.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid Refresh Token.");
            }
            else if (user.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Token expired.");
            }

            string token = _jwtService.GenerateToken(user);
            _refreshTokenService.SetRefreshToken(userId);

            return Ok(token);
        }
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // Xóa thông tin phiên đăng nhập và token của người dùng
            HttpContext.Session.Clear();
            Response.Cookies.Delete("refreshToken");

            return Ok("Logout successful");
        }
    }

}
 