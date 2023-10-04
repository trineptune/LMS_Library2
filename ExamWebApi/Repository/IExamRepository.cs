using ExamWebApi.DTO;
using ExamWebApi.Models;

namespace ExamWebApi.Repository
{
    public interface IExamRepository
    {
        Task<List<Exam>> GetAllExams();
        Task<List<Exam>> GetUnapprovedExam();
        Task<List<Exam>> GetapprovedExam();
        Task<Exam> GetExambyId(int id);
        Task AddExam(ExamDTO examdto);
        Task<bool> UpdateExam(int id, ExamDTO examdto);
        Task<bool> DeleteExam(int id);
        Task ApproveExam(int id);
        Task DisapproveExam(int id);
    }
}
