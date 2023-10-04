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
    public class ExamContentsController : ControllerBase
    {
        private readonly IExamContentRepository _examContentRepository;

        public ExamContentsController(IExamContentRepository examContentRepository)
        {
            _examContentRepository = examContentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ExamContent>>> GetAllExamContents()
        {
            var examContents = await _examContentRepository.GetAllExamContent();
            return Ok(examContents);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExamContent>> GetExamContentById(int id)
        {
            var examContent = await _examContentRepository.GetExamContentbyId(id);
            if (examContent == null)
            {
                return NotFound();
            }
            return Ok(examContent);
        }

        [HttpPost]
        public async Task<IActionResult> AddExamContent(ExamContentDTO examDto)
        {
            await _examContentRepository.AddExamContet(examDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExamContent(int id, ExamContentDTO examDto)
        {
            var result = await _examContentRepository.UpdateExamContent(id, examDto);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamContent(int id)
        {
            var result = await _examContentRepository.DeleteExamContent(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}