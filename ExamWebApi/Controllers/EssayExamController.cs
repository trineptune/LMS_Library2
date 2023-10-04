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
    public class EssayExamsController : ControllerBase
    {
        private readonly IExamEssayRepository _examEssayRepository;

        public EssayExamsController(IExamEssayRepository examEssayRepository)
        {
            _examEssayRepository = examEssayRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<EssayExam>>> GetAllEssayExams()
        {
            var essayExams = await _examEssayRepository.GetAllExamEssay();
            return Ok(essayExams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EssayExam>> GetEssayExamById(int id)
        {
            var essayExam = await _examEssayRepository.GetExamEssaybyId(id);
            if (essayExam == null)
            {
                return NotFound();
            }
            return Ok(essayExam);
        }

        [HttpPost]
        public async Task<IActionResult> AddEssayExam(EssayExamDTO examDto)
        {
            await _examEssayRepository.AddEssayExam(examDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEssayExam(int id, EssayExamDTO examDto)
        {
            var result = await _examEssayRepository.UpdateEssayExam(id, examDto);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEssayExam(int id)
        {
            var result = await _examEssayRepository.DeleteEssayExam(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}