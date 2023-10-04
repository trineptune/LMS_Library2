using ExamWebApi.Data;
using ExamWebApi.DTO;
using ExamWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamWebApi.Repository
{
    public class ExamContentRepository:IExamContentRepository
    {
        private readonly ExamDbContext _context;
        public ExamContentRepository(ExamDbContext context)
        {
            _context = context;
        }
        public async Task<List<ExamContent>> GetAllExamContent()
        {
            return await _context.ExamContents.ToListAsync();
        }
        public async Task<ExamContent> GetExamContentbyId(int id)
        {
            return await _context.ExamContents.FindAsync(id);
        }
        public async Task AddExamContet(ExamContentDTO examcontentdto)
        {
            var newExam = new ExamContent
            {
                Content = examcontentdto.Content,
                ExamId = examcontentdto.ExamId,
            };
            _context.ExamContents.Add(newExam);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateExamContent(int id, ExamContentDTO examdto)
        {
            var exam = await _context.ExamContents.FindAsync(id);

            if (exam == null)
            {
                return false;
            }
            exam.Content=examdto.Content;
            exam.ExamId= examdto.ExamId;

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteExamContent(int id)
        {
            var exam = await _context.ExamContents.FindAsync(id);
            if (exam == null)
            {
                return false;
            }

            _context.ExamContents.Remove(exam);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
