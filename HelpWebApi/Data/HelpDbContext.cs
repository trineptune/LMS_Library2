using HelpWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpWebApi.Data
{
    public class HelpDbContext:DbContext
    {
        public HelpDbContext(DbContextOptions<HelpDbContext> options) : base(options)
        {

        }
        public DbSet<HelpRequest> HelpRequests { get; set; }
    }

}
