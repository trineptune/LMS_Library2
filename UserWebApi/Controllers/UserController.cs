using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserWebApi.Models;
using UserWebApi.Repository;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
namespace UserWebApi.Controllers
{
    [ApiController]
    [Route("api/UserApi")]
    public class UserController : Controller
    {
        private readonly IUser _repo;
        private readonly IWebHostEnvironment _environment;

        public UserController(IUser repo, IWebHostEnvironment environment)
        {
            _repo = repo;
            _environment = environment;
        }
        [HttpGet]
        [Authorize(Roles = "LeaderShip")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await _repo.GetUsers());
        }
        [HttpGet("Key")]
        public IActionResult SearchUsers([FromQuery] string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return BadRequest("Từ khóa tìm kiếm không được để trống.");
            }

            var users = _repo.SearchUsers(key);
            if (users.Count == 0)
            {
                return NotFound();
            }

            return Ok(users);
        }
        [Authorize(Roles = "LeaderShip")]
        [HttpPost]
        public async Task<ActionResult<Role>> AddRole(UserDTO userDTO)
        {
            var createdUser = await _repo.AddUser(userDTO);

            return Ok(createdUser);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "LeaderShip")]
        public async Task<IActionResult> DeleteUser(int id)
        {

            var result = await _repo.DeleteUser(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "LeaderShip")]
        public async Task<IActionResult> UpdateRole([FromRoute] int id, UserDTO userdto)
        {
            var result = await _repo.UpdateUser(id, userdto);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
        [HttpPut("changepassword")]
        public async Task<IActionResult> ChangePassword( [FromBody] ChangePasswordModels model)
        {
            int userId = (int)HttpContext.Session.GetInt32("UserId");

            var result = await _repo.ChangePassword(userId, model.CurrentPassword, model.NewPassword);

            if (result)
            {
                return Ok("Đổi mật khẩu thành công.");
            }

            return BadRequest("Đổi mật khẩu không thành công.");
        }
       [HttpPost("{userId}/avatar")]
        public IActionResult AddOrUpdateAvatar(int userId, IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        // Tạo tên file duy nhất
        string uniqueFileName = Path.GetFileNameWithoutExtension(file.FileName)
            + "_" + Guid.NewGuid().ToString().Substring(0, 8)
            + Path.GetExtension(file.FileName);

        // Xác định thư mục lưu trữ avatar (ví dụ: wwwroot/uploads/avatars)
        string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", "avatars");

        // Tạo thư mục nếu không tồn tại
        Directory.CreateDirectory(uploadsFolder);

        // Đường dẫn đầy đủ của file avatar
        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

        // Lưu file avatar vào thư mục đã chỉ định
        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            file.CopyTo(fileStream);
        }

        // Gọi phương thức AddOrUpdateAvatar trong repository
        _repo.AddOrUpdateAvatar(userId, filePath);

        return Ok();
    }
        [HttpDelete("{userId}/avatar")]
        public IActionResult RemoveAvatar(int userId)
        {
            // Gọi phương thức RemoveAvatar trong repository
            _repo.RemoveAvatar(userId);

            return Ok();
        }
    }
}
