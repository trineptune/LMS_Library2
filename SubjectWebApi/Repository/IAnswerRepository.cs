using SubjectWebApi.DTO;
using SubjectWebApi.Models;

namespace SubjectWebApi.Repository
{
    public interface IAnswerRepository
    {
        Task<IEnumerable<Answer>> GetAllAnswers();
        Task<Answer> GetAnswerById(int id);
        Task<AnswerDTO> AddAnswer(AnswerDTO answerdto);
        Task<bool> UpdateAnswer(int id, AnswerDTO answerdto);
        Task<bool> DeleteAnswer(int id);
    }
}
