using SubjectWebApi.DTO;
using SubjectWebApi.Models;

namespace SubjectWebApi.Repository
{
    public interface IClassrepository
    {
        Task<IEnumerable<Class>> GetAllClass();
        Task<Class> GetClassById(int id);
        Task<ClassDTO> AddClass(ClassDTO classdto);
        Task<bool> UpdateClass(int id, ClassDTO classdto);
        Task<bool> DeleteClass(int id);
    }
}
