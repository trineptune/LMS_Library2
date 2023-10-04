using ExamWebApi.DTO;
using ExamWebApi.Models;

namespace ExamWebApi.Repository
{
    public interface IExamAnswerRepository
    {
        Task<List<ExamAnswer>> GetAllExamAnswer();
        Task<ExamAnswer> GetExamAnswerById(int id);
        Task AddExamAnswer(ExamAnswerDTO examdto);
        Task<bool> UpdateExamAnswer(int id, ExamAnswerDTO examdto);
        Task<bool> DeleteExamAnswer(int id);
    }
}
