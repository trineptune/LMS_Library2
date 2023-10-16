using NotificationWebApi.DTO;
using NotificationWebApi.Models;

namespace NotificationWebApi.Repository
{
    public interface INotificationRepository
    {

        Task<IEnumerable<Notification>> GetNotifications(int userId);
        Task<List<Notification>> GetUnReadNotification(int userId);
        Task<List<Notification>> GetReadNotification(int userId);
        Task<Notification> GetNotificationById(int userId, int id);
        Task<NotificationDTO> AddNotification(NotificationDTO notiDto);
        Task<bool> UpdateNotification(int id, NotificationDTO notificationDto);
        Task DeleteNotification(int id);
        Task CheckNotification(int userid,int id);
        Task UncheckNotification(int userid,int id);
    }
}
