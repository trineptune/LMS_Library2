using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubjectWebApi.DTO;
using SubjectWebApi.Models;
using SubjectWebApi.Repository;

namespace SubjectWebApi.Controllers
{
    [ApiController]
    [Route("api/ResoureApi")]
    public class ResoureController : Controller
    {
        private readonly IResourcesRepository _repo;
        public ResoureController(IResourcesRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [Authorize(Roles = "LeaderShip,Teacher")]
        public async Task<IActionResult> GetAllResourcesFiles()
        {
            var resourcesFiles = await _repo.GetAllResourcesFiles();
            return Ok(resourcesFiles);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "LeaderShip,Teacher")]
        public async Task<IActionResult> GetResourcesFileById(int id)
        {
            var resourcesFile = await _repo.GetResourcesFileById(id);
            if (resourcesFile == null)
            {
                return NotFound();
            }
            return Ok(resourcesFile);
        }
        [HttpPost]
        [Authorize(Roles = "LeaderShip,Teacher")]
        public async Task<IActionResult> AddResourcesFile(IFormFile file, int userId,int LessinId)
        {
            if (file == null || file.Length <= 0)
            {
                return BadRequest("No file uploaded");
            }

            if (!IsValidFileExtension(file.FileName))
            {
                return BadRequest("Invalid file extension");
            }

            var targetDirectory = Path.Combine(Directory.GetCurrentDirectory(), "FileResoure", "File");
            var fileName = file.FileName;
            var filePath = Path.Combine(targetDirectory, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var resourcesFile = new ResoureDTO
            {
                FileName = fileName,
                FilePath = filePath,
                Approve = false,
                UserId = userId,
                LessionId = LessinId
            };

            await _repo.AddResourcesFile(resourcesFile);

            return Ok(resourcesFile.FileName);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "LeaderShip")]
        public async Task<IActionResult> UpdateRole([FromRoute] int id, ResoureDTO resouredto)
        {
            var result = await _repo.UpdateResoure(id, resouredto);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "LeaderShip")]
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
        [HttpGet("unapproved")]
        [Authorize(Roles = "LeaderShip,Teacher")]
        public async Task<IActionResult> GetUnapprovedResourcesFiles()
        {
            var unapprovedFiles = await _repo.GetUnapprovedResourcesFiles();
            return Ok(unapprovedFiles);
        }

        [HttpGet("approvedFile")]
        [Authorize(Roles = "LeaderShip,Teacher,Student")]
        public async Task<IActionResult> GetapproveFile()
        {
            var approvedFiles = await _repo.GetapprovedResourcesFiles();
            return Ok(approvedFiles);
        }

        [HttpPost("{id}/approve")]
        [Authorize(Roles = "LeaderShip")]
        public async Task<IActionResult> ApproveResourcesFile(int id)
        {
            var existingResourcesFile = await _repo.GetResourcesFileById(id);
            if (existingResourcesFile == null)
            {
                return NotFound();
            }

            await _repo.ApproveResourcesFile(id);

            return NoContent();
        }

        [HttpPost("{id}/disapprove")]
        [Authorize(Roles = "LeaderShip")]
        public async Task<IActionResult> DisapproveResourcesFile(int id)
        {
            var existingResourcesFile = await _repo.GetResourcesFileById(id);
            if (existingResourcesFile == null)
            {
                return NotFound();
            }

            await _repo.DisapproveResourcesFile(id);

            return NoContent();
        }

        private bool IsValidFileExtension(string fileName)
        {
            var allowedExtensions = new[] { ".txt", ".pdf" };
            var fileExtension = Path.GetExtension(fileName).ToLowerInvariant();
            return allowedExtensions.Contains(fileExtension);
        }
    }
}
