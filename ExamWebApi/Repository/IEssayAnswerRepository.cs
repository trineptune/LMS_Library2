using ExamWebApi.DTO;
using ExamWebApi.Models;

namespace ExamWebApi.Repository
{
    public interface IEssayAnswerRepository
    {
        Task<List<EssayAnswer>> GetAllEssayAnswer();
        Task<EssayAnswer> GetExamEssayAnswerbyId(int id);
        Task AddEssayAnswer(EssayAnswerDTO examdto);
        Task<bool> UpdateEssayAnswer(int id, EssayAnswerDTO examdto);
        Task<bool> DeleteEssayAnswer(int id);
    }
}
