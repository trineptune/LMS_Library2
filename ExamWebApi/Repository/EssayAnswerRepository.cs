using ExamWebApi.Data;
using ExamWebApi.DTO;
using ExamWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamWebApi.Repository
{
    public class EssayAnswerRepository:IEssayAnswerRepository
    {
        public readonly ExamDbContext _context;
        public EssayAnswerRepository(ExamDbContext context)
        {
            _context = context;
        }
        public async Task<List<EssayAnswer>> GetAllEssayAnswer()
        {
            return await _context.EssayAnswers.ToListAsync();
        }
        public async Task<EssayAnswer> GetExamEssayAnswerbyId(int id)
        {
            return await _context.EssayAnswers.FindAsync(id);
        }
        public async Task AddEssayAnswer(EssayAnswerDTO examdto)
        {
            var newAnswer = new EssayAnswer
            {
                EssayId = examdto.EssayId,
                Answer = examdto.Answer,
                UserId= examdto.UserId,
            };
            _context.EssayAnswers.Add(newAnswer);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateEssayAnswer(int id, EssayAnswerDTO examdto)
        {
            var answer = await _context.EssayAnswers.FindAsync(id);

            if (answer == null)
            {
                return false;
            }
            answer.Answer = examdto.Answer;
            answer.UserId = examdto.UserId;
            answer.EssayId = examdto.EssayId;

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteEssayAnswer(int id)
        {
            var exam = await _context.EssayAnswers.FindAsync(id);
            if (exam == null)
            {
                return false;
            }

            _context.EssayAnswers.Remove(exam);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
