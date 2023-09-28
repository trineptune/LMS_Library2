using Microsoft.EntityFrameworkCore;
using SubjectWebApi.Data;
using SubjectWebApi.DTO;
using SubjectWebApi.Models;

namespace SubjectWebApi.Repository
{
    public class QuestionRepository:IQuestionRepository
    {
        private readonly SubjectDbContext _context;
        public QuestionRepository (SubjectDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Question>> GetAllQuestions()
        {
            return await _context.Question.ToListAsync();
        }

        public async Task<Question> GetQuestionById(int id)
        {
            return await _context.Question.FindAsync(id);
        }

        public async Task<QuestionDTO> AddQuestion(QuestionDTO questiondto)
        {
            var newQuestion = new Question
            {
                Title=questiondto.Title,
                Description=questiondto.Description,
                UserId =questiondto.UserId,
                LessionId=questiondto.LessionId,


            };
            _context.Question.Add(newQuestion);
            await _context.SaveChangesAsync();

            return questiondto;
        }

        public async Task<bool> UpdateQuestion(int id, QuestionDTO questiondto)
        {
            var question = await _context.Question.FindAsync(id);

            if (question == null)
            {
                return false;
            }

            question.Title= questiondto.Title;
            question.Description= questiondto.Description;
            question.UserId= questiondto.UserId;
            question.LessionId= questiondto.LessionId;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteQuestion(int id)
        {
            var question = await _context.Question.FindAsync(id);
            if (question == null)
            {
                return false;
            }

            _context.Question.Remove(question);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
