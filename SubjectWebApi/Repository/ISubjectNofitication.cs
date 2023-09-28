using SubjectWebApi.DTO;
using SubjectWebApi.Models;

namespace SubjectWebApi.Repository
{
    public interface ISubjectNofitication
    {
        Task<IEnumerable<SubjectNotification>> GetAllSubNotifications();
        Task<SubjectNotification> GetSubnotificationById(int id);
        Task<SubjectNotificationDTO> AddSubnotification(SubjectNotificationDTO subjectnotificationdto);
        Task<bool> UpdateSubnotification(int id, SubjectNotificationDTO subnotificationdto);
        Task<bool> DeleteSubnotification(int id);
    }
}
