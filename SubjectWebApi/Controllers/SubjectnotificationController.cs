using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubjectWebApi.DTO;
using SubjectWebApi.Models;
using SubjectWebApi.Repository;

namespace SubjectWebApi.Controllers
{
    [ApiController]
    [Route("api/SubjectnotificationApi")]
    public class SubjectnotificationController : Controller
    {
        private readonly ISubjectNofitication _repo;
        public SubjectnotificationController(ISubjectNofitication repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Authorize(Roles = "LeaderShip,Teacher,Student")]
        public async Task<ActionResult<IEnumerable<SubjectNotification>>> GetSubjectnotification()
        {
            return Ok(await _repo.GetAllSubNotifications());
        }
        [Authorize(Roles = "LeaderShip,Teacher")]
        [HttpPost]
        public async Task<ActionResult<Subject>> AddSubjectNotification(SubjectNotificationDTO subjectnotificationDTO)
        {
            var createdSubjectnotification = await _repo.AddSubnotification(subjectnotificationDTO);

            return Ok(createdSubjectnotification);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "LeaderShip,Teacher")]
        public async Task<IActionResult> DeleteSubjectNotification(int id)
        {

            var result = await _repo.DeleteSubnotification(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "LeaderShip,Teacher")]
        public async Task<IActionResult> UpdateSubjectNotification([FromRoute] int id,SubjectNotificationDTO subjecnotificationdto)
        {
            var result = await _repo.UpdateSubnotification(id, subjecnotificationdto);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}
