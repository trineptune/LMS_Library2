using Microsoft.EntityFrameworkCore;
using NotificationWebApi.Models;

namespace NotificationWebApi.Data
{
    public class NotificationDbContext : DbContext
    {
        public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options)
        {

        }
        public DbSet<Notification> Notifications { get; set; }
    }
}
