using ExamWebApi.DTO;
using ExamWebApi.Models;

namespace ExamWebApi.Repository
{
    public interface IExamContentRepository
    {
        Task<List<ExamContent>> GetAllExamContent();
        Task<ExamContent> GetExamContentbyId(int id);
        Task AddExamContet(ExamContentDTO examcontentdto);
        Task<bool> UpdateExamContent(int id, ExamContentDTO examdto);
        Task<bool> DeleteExamContent(int id);
    }
}
