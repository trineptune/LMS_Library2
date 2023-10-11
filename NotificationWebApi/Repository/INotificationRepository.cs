using NotificationWebApi.DTO;
using NotificationWebApi.Models;

namespace NotificationWebApi.Repository
{
    public interface INotificationRepository
    {

        Task<IEnumerable<Notification>> GetNotificationsBy(int userId);
        Task<List<Notification>> GetUnReadNotification();
        Task<List<Notification>> GetReadNotification();
        Task<Notification> GetNotificationById(int userId, int id);
        Task<NotificationDTO> AddNotification(NotificationDTO notiDto);
        Task<bool> UpdateNotification(int id, NotificationDTO notificationDto);
        Task DeleteNotification(int id);
        Task CheckNotification(int id, int userId);
        Task UncheckNotification(int id, int userId);
    }
}
