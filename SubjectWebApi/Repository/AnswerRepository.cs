using Microsoft.EntityFrameworkCore;
using SubjectWebApi.Data;
using SubjectWebApi.DTO;
using SubjectWebApi.Models;

namespace SubjectWebApi.Repository
{
    public class AnswerRepository:IAnswerRepository
    {
        private readonly SubjectDbContext _context;
        public AnswerRepository (SubjectDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Answer>> GetAllAnswers()
        {
            return await _context.Answers.ToListAsync();
        }

        public async Task<Answer> GetAnswerById(int id)
        {
            return await _context.Answers.FindAsync(id);
        }

        public async Task<AnswerDTO> AddAnswer(AnswerDTO answerdto)
        {
            var newAnswer = new Answer
            {
                AnswerDescription=answerdto.AnswerDescription,
                UserId=answerdto.UserId,
                QuestionId=answerdto.QuestionId,


            };
            _context.Answers.Add(newAnswer);
            await _context.SaveChangesAsync();

            return answerdto;
        }

        public async Task<bool> UpdateAnswer(int id, AnswerDTO answerdto)
        {
            var answer = await _context.Answers.FindAsync(id);

            if (answer == null)
            {
                return false;
            }

            answer.AnswerDescription= answerdto.AnswerDescription;
            answer.UserId= answerdto.UserId;
            answer.QuestionId= answerdto.QuestionId;    
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAnswer(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer == null)
            {
                return false;
            }

            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
