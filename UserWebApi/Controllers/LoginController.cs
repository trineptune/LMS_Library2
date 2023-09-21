using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using UserWebApi.Models;
using UserWebApi.Repository;
using UserWebApi.Service;

namespace UserWebApi.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly AuthService _authService;
        private readonly IUser _repo;
        public LoginController(AuthService authService,IUser repo)
        {
            _authService = authService;
            _repo = repo;
        }

        [HttpPost]
        public IActionResult Login(LoginDTO request)
        {
            string token = _authService.Authenticate(request.Email, request.Password, request.Role, HttpContext);

            if (token != null)
            {
                HttpContext.Session.SetInt32("UserId", );

                return Ok(new { Token = token });
            }
        
            return Unauthorized("Invalid credentials");
        }
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // Lấy thông tin người dùng hiện tại từ phiên làm việc hoặc token
            int userId = GetCurrentUserId();

            // Xóa thông tin xác thực của người dùng
            _repo.UpdateUserAuthentication(userId, null, DateTime.MinValue, DateTime.MinValue);

            // Xóa phiên làm việc (nếu có)
            HttpContext.Session.Clear();

            // Xóa cookie (nếu có)
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }

            return Ok();
        }
        private int GetCurrentUserId()
        {
            // Lấy thông tin người dùng từ phiên làm việc
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;

            if (userId == 0)
            {
                // Nếu không có thông tin người dùng từ phiên làm việc, bạn có thể lấy thông tin từ Access Token hoặc Token JWT (nếu sử dụng)
                string accessToken = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                if (!string.IsNullOrEmpty(accessToken))
                {
                    // Giải mã Token JWT để lấy thông tin người dùng
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.ReadJwtToken(accessToken);

                    string userIdString = token.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;

                    int.TryParse(userIdString, out userId);
                }
            }

            return userId;
        }

    }

}
 