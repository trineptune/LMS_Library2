using Microsoft.EntityFrameworkCore;
using SubjectWebApi.Data;
using SubjectWebApi.DTO;
using SubjectWebApi.Models;

namespace SubjectWebApi.Repository
{
    public class SubjectNoficationRepository : ISubjectNofitication
    {
        private readonly SubjectDbContext _context;
        public SubjectNoficationRepository(SubjectDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SubjectNotification>> GetAllSubNotifications()
        {
            return await _context.SubjectNotifications.ToListAsync();
        }

        public async Task<SubjectNotification> GetSubnotificationById(int id)
        {
            return await _context.SubjectNotifications.FindAsync(id);
        }

        public async Task<SubjectNotificationDTO> AddSubnotification(SubjectNotificationDTO subjectNotificationdto)
        {
            var newSubnotification = new SubjectNotification
            {
               Title=subjectNotificationdto.Title,
               Description=subjectNotificationdto.Description,
               SubjectId=subjectNotificationdto.SubjectId,
               UserId=subjectNotificationdto.UserId,


            };
            _context.SubjectNotifications.Add(newSubnotification);
            await _context.SaveChangesAsync();

            return subjectNotificationdto;
        }

        public async Task<bool> UpdateSubnotification(int id, SubjectNotificationDTO subjectnotificationdto)
        {
            var subjectNotification = await _context.SubjectNotifications.FindAsync(id);

            if (subjectNotification == null)
            {
                return false;
            }

            subjectNotification.Title= subjectnotificationdto.Title;
            subjectNotification.Description = subjectnotificationdto.Description;
            subjectNotification.SubjectId = subjectnotificationdto.SubjectId;
            subjectNotification.UserId = subjectnotificationdto.UserId;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteSubnotification(int id)
        {
            var subjectnotification = await _context.SubjectNotifications.FindAsync(id);
            if (subjectnotification == null)
            {
                return false;
            }

            _context.SubjectNotifications.Remove(subjectnotification);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
