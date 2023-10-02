using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubjectWebApi.DTO;
using SubjectWebApi.Models;
using SubjectWebApi.Repository;

namespace SubjectWebApi.Controllers
{
    [ApiController]
    [Route("api/Answer")]
    public class AnswerController : Controller
    {
        private readonly IAnswerRepository _repo;
        public AnswerController(IAnswerRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Authorize(Roles = "LeaderShip,Student,Teacher")]
        public async Task<ActionResult<IEnumerable<Answer>>> GetAnswer()
        {
            return Ok(await _repo.GetAllAnswers());
        }
        [Authorize(Roles = "LeaderShip,Student,Teacher")]
        [HttpPost]
        public async Task<ActionResult<Answer>> AddAnswer(AnswerDTO answerdto)
        {
            var createdSubject = await _repo.AddAnswer(answerdto);

            return Ok(createdSubject);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "LeaderShip,Student,Teacher")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {

            var result = await _repo.DeleteAnswer(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "LeaderShip,Student,Teacher")]
        public async Task<IActionResult> UpdateAnswer([FromRoute] int id,AnswerDTO answerdto)
        {
            var result = await _repo.UpdateAnswer(id, answerdto);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}
