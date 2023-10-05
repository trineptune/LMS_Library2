using ExamWebApi.DTO;
using ExamWebApi.Models;
using ExamWebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EssayAnswerController : ControllerBase
    {
        private readonly IEssayAnswerRepository _essayAnswerRepository;

        public EssayAnswerController(IEssayAnswerRepository essayAnswerRepository)
        {
            _essayAnswerRepository = essayAnswerRepository;
        }

        // GET: api/EssayAnswer
        [HttpGet]
        public async Task<ActionResult<List<EssayAnswer>>> GetAllEssayAnswers()
        {
            var essayAnswers = await _essayAnswerRepository.GetAllEssayAnswer();
            return Ok(essayAnswers);
        }

        // GET: api/EssayAnswer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EssayAnswer>> GetEssayAnswerById(int id)
        {
            var essayAnswer = await _essayAnswerRepository.GetExamEssayAnswerbyId(id);

            if (essayAnswer == null)
            {
                return NotFound();
            }

            return Ok(essayAnswer);
        }

        // POST: api/EssayAnswer
        [HttpPost]
        public async Task<ActionResult> AddEssayAnswer(EssayAnswerDTO essayAnswerDTO)
        {
            await _essayAnswerRepository.AddEssayAnswer(essayAnswerDTO);
            return Ok();
        }

        // PUT: api/EssayAnswer/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEssayAnswer(int id, EssayAnswerDTO essayAnswerDTO)
        {
            var result = await _essayAnswerRepository.UpdateEssayAnswer(id, essayAnswerDTO);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        // DELETE: api/EssayAnswer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEssayAnswer(int id)
        {
            var result = await _essayAnswerRepository.DeleteEssayAnswer(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}