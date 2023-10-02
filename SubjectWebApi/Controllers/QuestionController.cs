using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubjectWebApi.DTO;
using SubjectWebApi.Models;
using SubjectWebApi.Repository;

namespace SubjectWebApi.Controllers
{
    [ApiController]
    [Route("api/QuestionApi")]
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository _repo;
        public QuestionController(IQuestionRepository repo)
        {
             _repo = repo;
        }
        [HttpGet]
        [Authorize(Roles = "LeaderShip,Student,Teacher")]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestion()
        {
            return Ok(await _repo.GetAllQuestions());
        }
        [Authorize(Roles = "LeaderShip,Student,Teacher")]
        [HttpPost]
        public async Task<ActionResult<Question>> AddQuestion(QuestionDTO questiondto)
        {
            var createdquestion = await _repo.AddQuestion(questiondto);

            return Ok(createdquestion);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "LeaderShip,Student,Teacher")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {

            var result = await _repo.DeleteQuestion(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "LeaderShip,Student,Teacher")]
        public async Task<IActionResult> UpdateQuestion([FromRoute] int id, QuestionDTO questiondto)
        {
            var result = await _repo.UpdateQuestion(id, questiondto);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}
