using FileWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FileWebApi.Data
{
    public class FileResoureDbContext: DbContext
    {
        public FileResoureDbContext(DbContextOptions<FileResoureDbContext> options) : base(options)
        {

        }
        public DbSet<ResoureFile> ResoureFiles { get; set;}
    }
}
