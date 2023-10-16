using Microsoft.EntityFrameworkCore;
using NotificationWebApi.Data;
using NotificationWebApi.DTO;
using NotificationWebApi.Models;

namespace NotificationWebApi.Repository
{
    public class NotificationRepository:INotificationRepository
    {
        private readonly NotificationDbContext _context;
        public NotificationRepository(NotificationDbContext context)
        {
            _context = context;
      }
        public async Task<IEnumerable<Notification>> GetNotifications(int userId)
        {
            return await _context.Notifications.Where(n => n.UserId == userId).ToListAsync();
        }
       public async Task<List<Notification>> GetUnReadNotification(int userId)
{
    return await _context.Notifications.Where(rf => !rf.Check && rf.UserId == userId).ToListAsync();
}
        public async Task<List<Notification>> GetReadNotification(int userId)
        {
            return await _context.Notifications.Where(rf => rf.Check && rf.UserId == userId).ToListAsync();
        }
        public async Task<Notification> GetNotificationById(int userId, int id)
        {
            return await _context.Notifications.FirstOrDefaultAsync(n => n.UserId == userId && n.Id == id);
        }

        public async Task<NotificationDTO> AddNotification(NotificationDTO notiDto)
        {
            notiDto.Check = false;
            var newNoti = new Notification
            {
                Content=notiDto.Content,
                Title=notiDto.Title,    
                UserId=notiDto.UserId,  
                Check=notiDto.Check,

            };
            _context.Notifications.Add(newNoti);
            await _context.SaveChangesAsync();

            return notiDto;
        }

        public async Task<bool> UpdateNotification(int id, NotificationDTO notificationDto)
        {
            var noti = await _context.Notifications.FindAsync(id);

            if (noti == null)
            {
                return false;
            }
            noti.Check = notificationDto.Check;
            noti.Title=notificationDto.Title;
            noti.UserId=notificationDto.UserId;
            noti.Content=notificationDto.Content;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task DeleteNotification(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            _context.Notifications.Remove(notification);
            await _context.SaveChangesAsync();
        }
        public async Task CheckNotification(int userId,int id)
        {
            var Notifcation = await GetNotificationById(userId,id);
            if (Notifcation != null)
            {
                Notifcation.Check = true;
                _context.Notifications.Update(Notifcation);
                await _context.SaveChangesAsync();
            }
        }
        public async Task UncheckNotification(int userid,int Id)
        {
            var Notifcation = await GetNotificationById(userid,Id);
            if (Notifcation != null)
            {
                Notifcation.Check = false;
                _context.Notifications.Update(Notifcation);
                await _context.SaveChangesAsync();
            }
        }

    }
}

