using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubjectWebApi.DTO;
using SubjectWebApi.Migrations;
using SubjectWebApi.Models;
using SubjectWebApi.Repository;

namespace SubjectWebApi.Controllers
{
    [ApiController]
    [Route("api/SubjectApi")]
    public class SubjectController : Controller
    {
        private readonly ISubjectRepository _repo;
        public SubjectController(ISubjectRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
       // [Authorize(Roles = "LeaderShip")]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubject()
        {
            return Ok(await _repo.GetAllSubjects());
        }
        [Authorize(Roles = "LeaderShip")]
        [HttpPost]
        public async Task<ActionResult<Subject>> AddSubject(SubjectDTO subjectDTO)
        {
            var createdSubject = await _repo.AddSubject(subjectDTO);

            return Ok(createdSubject);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "LeaderShip")]
        public async Task<IActionResult> DeleteSubject(int id)
        {

            var result = await _repo.DeleteSubject(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "LeaderShip")]
        public async Task<IActionResult> UpdateRole([FromRoute] int id, SubjectDTO subjectdto)
        {
            var result = await _repo.UpdateSubject(id, subjectdto);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}
