using ExamWebApi.DTO;
using ExamWebApi.Models;

namespace ExamWebApi.Repository
{
    public interface IExamEssayRepository
    {
        Task<List<EssayExam>> GetAllExamEssay();
        Task<EssayExam> GetExamEssaybyId(int id);
        Task AddEssayExam(EssayExamDTO examdto);
        Task<bool> UpdateEssayExam(int id, EssayExamDTO examdto);
        Task<bool> DeleteEssayExam(int id);
    }
}
