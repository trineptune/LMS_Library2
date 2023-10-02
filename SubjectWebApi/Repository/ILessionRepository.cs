using SubjectWebApi.DTO;
using SubjectWebApi.Models;

namespace SubjectWebApi.Repository
{
    public interface ILessionRepository
    {
        Task<IEnumerable<Lession>> GetAllLessions();
        Task<List<Lession>> GetUnapprovedLession();
        Task<List<Lession>> GetapprovedLession();
        Task<Lession> GetLessionById(int id);
        Task<LessionDTO> AddLession(LessionDTO lessionDto);
        Task<bool> UpdateLession(int id, LessionDTO lessiondto);
        Task<bool> DeleteLession(int id);
        Task DisapproveResourcesFile(int id);
        Task ApproveResourcesFile(int id);
    }
}
