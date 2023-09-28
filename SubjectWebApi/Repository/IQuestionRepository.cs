using SubjectWebApi.DTO;
using SubjectWebApi.Models;

namespace SubjectWebApi.Repository
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetAllQuestions();
        Task<Question> GetQuestionById(int id);
        Task<QuestionDTO> AddQuestion(QuestionDTO questionDto);
        Task<bool> UpdateQuestion(int id,QuestionDTO questiondto);
        Task<bool> DeleteQuestion(int id);
    }
}
