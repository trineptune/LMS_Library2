using ExamWebApi.Data;
using ExamWebApi.DTO;
using ExamWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamWebApi.Repository
{
    public class ExamAnswerRepository:IExamAnswerRepository
    {
        private readonly ExamDbContext _context;
        public ExamAnswerRepository(ExamDbContext context)
        {
            _context = context;
        }
        public async Task<List<ExamAnswer>> GetAllExamAnswer()
        {
            return await _context.ExamAnswers.ToListAsync();
        }
        public async Task<ExamAnswer> GetExamAnswerById(int id)
        {
            return await _context.ExamAnswers.FindAsync(id);
        }
        public async Task AddExamAnswer(ExamAnswerDTO examdto)
        {
            var newExam = new ExamAnswer
            {
                Content = examdto.Content,
                IsCorrect = examdto.IsCorrect,
                QuestionId = examdto.QuestionId,
                UserId = examdto.UserId,
            };
            _context.ExamAnswers.Add(newExam);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateExamAnswer(int id, ExamAnswerDTO examdto)
        {
            var exam = await _context.ExamAnswers.FindAsync(id);

            if (exam == null)
            {
                return false;
            }
            exam.Content= examdto.Content;
            exam.IsCorrect = examdto.IsCorrect;
            exam.QuestionId= examdto.QuestionId;
            exam.UserId= examdto.UserId;
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteExamAnswer(int id)
        {
            var exam = await _context.ExamAnswers.FindAsync(id);
            if (exam == null)
            {
                return false;
            }

            _context.ExamAnswers.Remove(exam);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
