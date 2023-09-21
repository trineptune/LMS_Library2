using Microsoft.AspNetCore.Mvc;
using UserWebApi.Models;
using UserWebApi.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace UserWebApi.Controllers
{
    [ApiController]
    [Route("api/RoleApi")]
    public class RoleController:ControllerBase
    {
        private readonly IRole _repo;
        public RoleController(IRole repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Authorize(Roles = "LeaderShip")]
        public async Task<ActionResult<IEnumerable<Role>>> GetUsers()
        {
            return Ok(await _repo.GetAllRoles());
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "LeaderShip")]
        public async Task<ActionResult<Role>> GetRoleById(int id)
        {
            var role = await _repo.GetRoleById(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        
        }
        [Authorize(Roles = "LeaderShip")]
        [HttpPost]
        public async Task<ActionResult<Role>> AddRole(RoleDTO roleDto)
        {
            var createdRole = await _repo.AddRole(roleDto);

            return Ok(createdRole);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles ="LeaderShip")]
        public async Task<IActionResult> DeleteUser(int id)
        {

            var result = await _repo.DeleteRole(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "LeaderShip")]
        public async Task<IActionResult> UpdateRole([FromRoute] int id,RoleDTO roleDTO)
        {
            var result = await _repo.UpdateRole(id, roleDTO);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}
