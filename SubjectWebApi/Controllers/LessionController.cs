using Microsoft.AspNetCore.Mvc;
using SubjectWebApi.DTO;
using SubjectWebApi.Models;
using SubjectWebApi.Repository;

namespace SubjectWebApi.Controllers
{
    [ApiController]
    [Route("api/LessionController")]
    public class LessionController : Controller
    {
        private readonly ILessionRepository _repo;
        public LessionController(ILessionRepository repo)
        {
            _repo=repo;
        }
        [HttpGet]
        //[Authorize(Roles = "LeaderShip")]
        public async Task<ActionResult<IEnumerable<Lession>>> GetLession()
        {
            return Ok(await _repo.GetAllLessions());
        }
        [HttpGet("unapproved")]
        public async Task<IActionResult> GetUnapprovedLession()
        {
            var unapprovedFiles = await _repo.GetUnapprovedLession();
            return Ok(unapprovedFiles);
        }
        //[Authorize(Roles = "LeaderShip")]
        [HttpPost]
        public async Task<ActionResult<Subject>> AddLession(LessionDTO lessiondto)
        {
            var createdLession = await _repo.AddLession(lessiondto);

            return Ok(createdLession);
        }
        [HttpDelete("{id}")]
        //[Authorize(Roles = "LeaderShip")]
        public async Task<IActionResult> DeleteLession(int id)
        {

            var result = await _repo.DeleteLession(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpPut("{id}")]
        //[Authorize(Roles = "LeaderShip")]
        public async Task<IActionResult> UpdateLession([FromRoute] int id, LessionDTO lessiondto)
        {
            var result = await _repo.UpdateLession(id, lessiondto);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
        [HttpPost("{id}/approve")]
        public async Task<IActionResult> ApproveLession(int id)
        {
            var existingResourcesFile = await _repo.GetLessionById(id);
            if (existingResourcesFile == null)
            {
                return NotFound();
            }

            await _repo.ApproveResourcesFile(id);

            return NoContent();
        }

        [HttpPost("{id}/disapprove")]
        public async Task<IActionResult> DisapproveLession(int id)
        {
            var existingResourcesFile = await _repo.GetLessionById(id);
            if (existingResourcesFile == null)
            {
                return NotFound();
            }

            await _repo.DisapproveResourcesFile(id);

            return NoContent();
        }
    }
}
