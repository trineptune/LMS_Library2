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
        [HttpPost]
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

            var filePath = Path.GetTempFileName();

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var resourcesFile = new ResoureDTO
            {
                FileName = file.FileName,
                FilePath = filePath,
                Approve = false,
                UserId = userId,
                LessionId=LessinId
            };

            await _repo.AddResourcesFile(resourcesFile);

            return Ok(resourcesFile.FileName);
        }
        [HttpPut("{id}")]
        //[Authorize(Roles = "LeaderShip")]
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
        public async Task<IActionResult> GetUnapprovedResourcesFiles()
        {
            var unapprovedFiles = await _repo.GetUnapprovedResourcesFiles();
            return Ok(unapprovedFiles);
        }
        [HttpPost("{id}/approve")]
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
