using FileWebApi.DTO;
using FileWebApi.Models;

namespace FileWebApi.Repository
{
    public interface IFileResourceRepository
    {
        Task<List<ResoureFile>> GetAllResourcesFiles();
        Task<ResoureFile> GetResourcesFileById(int id);
        Task AddResourcesFile(FileDTO resourcesFileDto);
        Task<bool> UpdateResoure(int id, FileDTO resoureDTO);
        Task<bool> DeleteResoure(int id);

    }
}
