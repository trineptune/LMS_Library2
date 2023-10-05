using ExamWebApi.Data;
using ExamWebApi.DTO;
using ExamWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamWebApi.Repository
{
    public class ExamEssayRepository:IExamEssayRepository
    {
        private readonly ExamDbContext _context;
        public ExamEssayRepository(ExamDbContext context)
        {
            _context = context;
        }
        public async Task<List<EssayExam>> GetAllExamEssay()
        {
            return await _context.EssayExams.ToListAsync();
        }
        public async Task<EssayExam> GetExamEssaybyId(int id)
        {
            return await _context.EssayExams.FindAsync(id);
        }
        public async Task AddEssayExam(EssayExamDTO examdto)
        {
            var newExam = new EssayExam
            {
                ExamId = examdto.ExamId,
                Titlte = examdto.Titlte,
                Difficulty=examdto.Difficulty,
            };
            _context.EssayExams.Add(newExam);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateEssayExam(int id, EssayExamDTO examdto)
        {
            var exam = await _context.EssayExams.FindAsync(id);

            if (exam == null)
            {
                return false;
            }
            exam.ExamId = examdto.ExamId;
            exam.Titlte= examdto.Titlte;
            exam.Difficulty= examdto.Difficulty;
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteEssayExam(int id)
        {
            var exam = await _context.EssayExams.FindAsync(id);
            if (exam == null)
            {
                return false;
            }

            _context.EssayExams.Remove(exam);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
