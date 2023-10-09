using FileWebApi.Data;
using FileWebApi.DTO;
using FileWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FileWebApi.Repository
{
    public class FileResourceRepository : IFileResourceRepository
    {
        private readonly FileResoureDbContext _context;

        public FileResourceRepository(FileResoureDbContext context)
        {
            _context = context;
        }

        public async Task<List<ResoureFile>> GetAllResourcesFiles()
        {
            return await _context.ResoureFiles.ToListAsync();
        }
        public async Task<ResoureFile> GetResourcesFileById(int id)
        {
            return await _context.ResoureFiles.FindAsync(id);
        }
        public async Task AddResourcesFile(FileDTO resourcesFileDto)
        {
            var newResoure = new ResoureFile
            {
                FileLength = resourcesFileDto.FileLength,
                FileName = resourcesFileDto.FileName,
                FilePath = resourcesFileDto.FilePath,
                FileType = resourcesFileDto.FileType,
                LastUpdated = DateTime.Now,
                SubjectId = resourcesFileDto.SubjectId,
                UserId= resourcesFileDto.UserId
            };
            _context.ResoureFiles.Add(newResoure);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateResoure(int id, FileDTO resoureDTO)
        {
            var resoure = await _context.ResoureFiles.FindAsync(id);

            if (resoure == null)
            {
                return false;
            }
            resoure.FileLength = resoureDTO.FileLength;
            resoure.LastUpdated = DateTime.Now;
            resoure.FilePath= resoureDTO.FilePath;
            resoure.FileName = resoureDTO.FileName;
            resoure.UserId= resoureDTO.UserId;
            resoure.SubjectId = resoureDTO.SubjectId;
            resoure.FileType = resoureDTO.FileType;

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteResoure(int id)
        {
            var resource = await _context.ResoureFiles.FindAsync(id);
            if (resource == null)
            {
                return false;
            }

            if (File.Exists(resource.FilePath))
            {
                File.Delete(resource.FilePath);
            }

            _context.ResoureFiles.Remove(resource);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
