using System.Collections.Generic;
using System.Threading.Tasks;
using HelpWebApi.DTO;
using HelpWebApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelpWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelpController : ControllerBase
    {
        private readonly IHelpRepository _helpRepository;

        public HelpController(IHelpRepository helpRepository)
        {
            _helpRepository = helpRepository;
        }

        [HttpGet]
        [Authorize(Roles = "LeaderShip,Student,Teacher")]
        public async Task<IActionResult> GetAllHelpRequests()
        {
            var helpRequests = await _helpRepository.GetAllHelpRequest();
            return Ok(helpRequests);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "LeaderShip,Student,Teacher")]
        public async Task<IActionResult> GetHelpRequestById(int id)
        {
            var helpRequest = await _helpRepository.GetHelpRequestById(id);
            if (helpRequest == null)
            {
                return NotFound();
            }

            return Ok(helpRequest);
        }

        [HttpPost]
        [Authorize(Roles = "LeaderShip,Student,Teacher")]
        public async Task<IActionResult> AddHelpRequest(HelpDTO helpdto)
        {
            var CreateHelp = await _helpRepository.AddHelpRequest(helpdto);

            return Ok(CreateHelp);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "LeaderShip,Student,Teacher")]
        public async Task<IActionResult> UpdateHelpRequest(int id, HelpDTO helpdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _helpRepository.UpdateHelpRequest(id, helpdto);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "LeaderShip,Student,Teacher")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var success = await _helpRepository.DeleteRequest(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}