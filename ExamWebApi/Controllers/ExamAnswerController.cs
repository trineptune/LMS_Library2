using ExamWebApi.DTO;
using ExamWebApi.Models;
using ExamWebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExamWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamAnswersController : ControllerBase
    {
        private readonly IExamAnswerRepository _examAnswerRepository;

        public ExamAnswersController(IExamAnswerRepository examAnswerRepository)
        {
            _examAnswerRepository = examAnswerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ExamAnswer>>> GetAllExamAnswers()
        {
            var examAnswers = await _examAnswerRepository.GetAllExamAnswer();
            return Ok(examAnswers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExamAnswer>> GetExamAnswerById(int id)
        {
            var examAnswer = await _examAnswerRepository.GetExamAnswerById(id);
            if (examAnswer == null)
            {
                return NotFound();
            }
            return Ok(examAnswer);
        }

        [HttpPost]
        public async Task<IActionResult> AddExamAnswer(ExamAnswerDTO examDto)
        {
            await _examAnswerRepository.AddExamAnswer(examDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExamAnswer(int id, ExamAnswerDTO examDto)
        {
            var result = await _examAnswerRepository.UpdateExamAnswer(id, examDto);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamAnswer(int id)
        {
            var result = await _examAnswerRepository.DeleteExamAnswer(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}