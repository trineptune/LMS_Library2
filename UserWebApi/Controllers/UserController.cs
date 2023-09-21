using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserWebApi.Models;
using UserWebApi.Repository;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace UserWebApi.Controllers
{
    [ApiController]
    [Route("api/UserApi")]
    public class UserController : Controller
    {
        private readonly IUser _repo;
        public UserController(IUser repo)
        {
            _repo = repo;
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
    }
}
