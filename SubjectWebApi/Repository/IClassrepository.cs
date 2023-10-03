using SubjectWebApi.DTO;
using SubjectWebApi.Models;

namespace SubjectWebApi.Repository
{
    public interface IClassrepository
    {
        Task<IEnumerable<Class>> GetAllClass();
        List<Subject> GetSubjectFavorate(int userId);
        Task<Class> GetClassById(int id);
        Task<ClassDTO> AddClass(ClassDTO classdto);
        Task<bool> UpdateClass(int id, ClassDTO classdto);
        Task<bool> DeleteClass(int id);
        List<Subject> GetSubjectsByUserId(int userId);
        List<Subject> GetSubjectsByName(int userId, string SubjectName);
        Task TickStartSubject(int UserId, int SubjectId);
        Task DisTickStartSubject(int UserId, int SubjectId);
    }
}
