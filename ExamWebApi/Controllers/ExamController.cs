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
    public class ExamsController : ControllerBase
    {
        private readonly IExamRepository _examRepository;

        public ExamsController(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Exam>>> GetAllExams()
        {
            var exams = await _examRepository.GetAllExams();
            return Ok(exams);
        }

        [HttpGet("unapproved")]
        public async Task<ActionResult<List<Exam>>> GetUnapprovedExams()
        {
            var exams = await _examRepository.GetUnapprovedExam();
            return Ok(exams);
        }

        [HttpGet("approved")]
        public async Task<ActionResult<List<Exam>>> GetApprovedExams()
        {
            var exams = await _examRepository.GetapprovedExam();
            return Ok(exams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exam>> GetExamById(int id)
        {
            var exam = await _examRepository.GetExambyId(id);
            if (exam == null)
            {
                return NotFound();
            }
            return Ok(exam);
        }

        [HttpPost]
        public async Task<IActionResult> AddExam(ExamDTO examDto)
        {
            await _examRepository.AddExam(examDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExam(int id, ExamDTO examDto)
        {
            var result = await _examRepository.UpdateExam(id, examDto);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var result = await _examRepository.DeleteExam(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPost("{id}/approve")]
        public async Task<IActionResult> ApproveExam(int id)
        {
            await _examRepository.ApproveExam(id);
            return Ok();
        }

        [HttpPost("{id}/disapprove")]
        public async Task<IActionResult> DisapproveExam(int id)
        {
            await _examRepository.DisapproveExam(id);
            return Ok();
        }
    }
}