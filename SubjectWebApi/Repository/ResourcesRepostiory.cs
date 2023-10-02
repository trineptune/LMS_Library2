using Microsoft.EntityFrameworkCore;
using SubjectWebApi.Data;
using SubjectWebApi.DTO;
using SubjectWebApi.Models;

namespace SubjectWebApi.Repository
{
    public class ResourcesRepostiory:IResourcesRepository
    {
        private readonly SubjectDbContext _context;
        public ResourcesRepostiory(SubjectDbContext context)
        {
            _context = context;
        }
        public async Task<List<ResourcesFile>> GetAllResourcesFiles()
        {
            return await _context.ResourcesFiles.ToListAsync();
        }
        public async Task<List<ResourcesFile>> GetUnapprovedResourcesFiles()
        {
            return await _context.ResourcesFiles.Where(rf => !rf.Approve).ToListAsync();
        }
        public async Task<ResourcesFile> GetResourcesFileById(int id)
        {
            return await _context.ResourcesFiles.FindAsync(id);
        }
        public async Task AddResourcesFile(ResoureDTO resourcesFileDto)
        {
            resourcesFileDto.Approve = false; // Mặc định là chưa được phê duyệt
            var newResoure = new ResourcesFile
            {
                FileName = resourcesFileDto.FileName,
                Approve = resourcesFileDto.Approve,
                FilePath = resourcesFileDto.FilePath,
                LessionId = resourcesFileDto.LessionId,
                UserId = resourcesFileDto.UserId,
            };
            _context.ResourcesFiles.Add(newResoure);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateResoure(int id,ResoureDTO resoureDTO)
        {
            var resoure = await _context.ResourcesFiles.FindAsync(id);

            if (resoure == null)
            {
                return false;
            }
            resoure.FileName = resoureDTO.FileName;
            resoure.FilePath = resoureDTO.FilePath;
            resoure.LessionId = resoureDTO.LessionId;
            resoure.UserId = resoureDTO.UserId;
            resoure.Approve = resoureDTO.Approve;

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteResoure(int id)
        {
            var resource = await _context.ResourcesFiles.FindAsync(id);
            if (resource == null)
            {
                return false;
            }

            if (File.Exists(resource.FilePath))
            {
                File.Delete(resource.FilePath);
            }

            _context.ResourcesFiles.Remove(resource);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task ApproveResourcesFile(int id)
        {
            var resourcesFile = await GetResourcesFileById(id);
            if (resourcesFile != null)
            {
                resourcesFile.Approve = true;
                _context.ResourcesFiles.Update(resourcesFile);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DisapproveResourcesFile(int id)
        {
            var resourcesFile = await GetResourcesFileById(id);
            if (resourcesFile != null)
            {
                resourcesFile.Approve = false;
                _context.ResourcesFiles.Update(resourcesFile);
                await _context.SaveChangesAsync();
            }
        }
    }
}
