using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubjectWebApi.DTO;
using SubjectWebApi.Models;
using SubjectWebApi.Repository;

namespace SubjectWebApi.Controllers
{
    [ApiController]
    [Route("api/ClassApi")]
    public class ClassController : Controller
    {
        private readonly IClassrepository _repo;
        public ClassController(IClassrepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Authorize(Roles = "LeaderShip")]
        public async Task<ActionResult<IEnumerable<Class>>> GetClass()
        {
            return Ok(await _repo.GetAllClass());
        }
       // [Authorize(Roles = "LeaderShip")]
        [HttpPost]
        public async Task<ActionResult<Subject>> AddClass(ClassDTO classDto)
        {
            var createdSubject = await _repo.AddClass(classDto);

            return Ok(createdSubject);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "LeaderShip")]
        public async Task<IActionResult> DeleteClass(int id)
        {

            var result = await _repo.DeleteClass(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "LeaderShip")]
        public async Task<IActionResult> UpdateClass([FromRoute] int id, ClassDTO classdto)
        {
            var result = await _repo.UpdateClass(id, classdto);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
        [HttpGet("{userId}")]
        [Authorize(Roles = "LeaderShip,Student,Teacher")]
        public IActionResult GetSubjectsByUserId(int userId)
        {
            var subjects = _repo.GetSubjectsByUserId(userId);
            return Ok(subjects);
        }
    }
}
