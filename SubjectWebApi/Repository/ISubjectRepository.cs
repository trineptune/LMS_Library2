using SubjectWebApi.DTO;
using SubjectWebApi.Models;

namespace SubjectWebApi.Repository
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetAllSubjects();
        Task<Subject> GetSubjectById(int id);
        Task<SubjectDTO> AddSubject(SubjectDTO SubjectDto);
        Task<bool> UpdateSubject(int id, SubjectDTO subjectDTO);
        Task<bool> DeleteSubject(int id);
    }
}
