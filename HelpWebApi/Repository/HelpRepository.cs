using HelpWebApi.Data;
using HelpWebApi.DTO;
using HelpWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpWebApi.Repository
{
    public class HelpRepository:IHelpRepository
    {
        private readonly HelpDbContext _context;
        public HelpRepository (HelpDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<HelpRequest>> GetAllHelpRequest()
        {
            return await _context.HelpRequests.ToListAsync();
        }

        public async Task<HelpRequest> GetHelpRequestById(int id)
        {
            return await _context.HelpRequests.FindAsync(id);
        }

        public async Task<HelpDTO> AddHelpRequest(HelpDTO helpdto)
        {
            var newRequest = new HelpRequest
            {
                Message = helpdto.Message,
                Title = helpdto.Title,
                UserId= helpdto.UserId,


            };
            _context.HelpRequests.Add(newRequest);
            await _context.SaveChangesAsync();

            return helpdto;
        }

        public async Task<bool> UpdateHelpRequest(int id, HelpDTO helpdto)
        {
            var request = await _context.HelpRequests.FindAsync(id);

            if (request == null)
            {
                return false;
            }

            request.Title = helpdto.Title;
            request.Message= helpdto.Message;
            request.UserId= helpdto.UserId;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteRequest(int id)
        {
            var request = await _context.HelpRequests.FindAsync(id);
            if (request == null)
            {
                return false;
            }

            _context.HelpRequests.Remove(request);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
