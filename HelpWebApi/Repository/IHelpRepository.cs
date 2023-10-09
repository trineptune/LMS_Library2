using HelpWebApi.DTO;
using HelpWebApi.Models;

namespace HelpWebApi.Repository
{
    public interface IHelpRepository
    {
        Task<IEnumerable<HelpRequest>> GetAllHelpRequest();
        Task<HelpRequest> GetHelpRequestById(int id);
        Task<HelpDTO> AddHelpRequest(HelpDTO helpdto);
        Task<bool> UpdateHelpRequest(int id, HelpDTO helpdto);
        Task<bool> DeleteRequest(int id);
    }
}
