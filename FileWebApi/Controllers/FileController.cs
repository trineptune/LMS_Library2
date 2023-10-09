using FileWebApi.DTO;
using FileWebApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileWebApi.Controllers
{
    public class FileController : Controller
    {
        private readonly IFileResourceRepository _repo;
        public FileController(IFileResourceRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("GetALl")]
        public async Task<IActionResult> GetAllResourcesFiles()
        {
            var resourcesFiles = await _repo.GetAllResourcesFiles();
            return Ok(resourcesFiles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResourcesFileById(int id)
        {
            var resourcesFile = await _repo.GetResourcesFileById(id);
            if (resourcesFile == null)
            {
                return NotFound();
            }
            return Ok(resourcesFile);
        }
        [HttpPost("PostFile")]
        public async Task<IActionResult> AddResourcesFile(IFormFile file, int userId, int SubjectId)
        {
            if (file == null || file.Length <= 0)
            {
                return BadRequest("No file uploaded");
            }


            var targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "FileResoure", "File");
            var fileName = file.FileName;
            var filePath = Path.Combine(targetDirectory, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var resourcesFile = new FileDTO
            {
                FileName = fileName,
                FilePath = filePath,
                FileLength=new FileInfo(filePath).Length / 1000000,
                LastUpdated=DateTime.Now,
                FileType=Path.GetExtension(filePath),
                UserId=userId,
                SubjectId=SubjectId,
            };

            await _repo.AddResourcesFile(resourcesFile);

            return Ok(resourcesFile.FileName);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole([FromRoute] int id, FileDTO resouredto)
        {
            var result = await _repo.UpdateResoure(id, resouredto);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResourcesFile(int id)
        {
            var existingResourcesFile = await _repo.GetResourcesFileById(id);
            if (existingResourcesFile == null)
            {
                return NotFound();
            }

            await _repo.DeleteResoure(id);

            return NoContent();
        }
    }
}
