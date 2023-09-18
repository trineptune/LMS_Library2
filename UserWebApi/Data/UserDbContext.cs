using Microsoft.EntityFrameworkCore;
using UserWebApi.Models;

namespace UserWebApi.Data
{
    public class UserDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne(u => u.role)
            .WithMany(r => r.user)
            .HasForeignKey(u => u.RoleId);
        }
    

    }

}
