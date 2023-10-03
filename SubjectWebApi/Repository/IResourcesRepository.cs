using SubjectWebApi.DTO;
using SubjectWebApi.Models;

namespace SubjectWebApi.Repository
{
    public interface IResourcesRepository
    {
        Task<List<ResourcesFile>> GetAllResourcesFiles();
        Task<List<ResourcesFile>> GetUnapprovedResourcesFiles();
        Task AddResourcesFile(ResoureDTO resourcesFileDto);
        Task<ResourcesFile> GetResourcesFileById(int id);
        Task<bool> UpdateResoure(int id, ResoureDTO resoureDTO);
        Task<bool> DeleteResoure(int id);
        Task ApproveResourcesFile(int id);
        Task DisapproveResourcesFile(int id);
        Task<List<ResourcesFile>> GetapprovedResourcesFiles();
    }
}
