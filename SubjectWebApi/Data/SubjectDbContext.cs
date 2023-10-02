using Microsoft.EntityFrameworkCore;
using SubjectWebApi.Models;

namespace SubjectWebApi.Data
{
    public class SubjectDbContext: DbContext
    {
        public SubjectDbContext(DbContextOptions<SubjectDbContext> options) : base(options)
        {

        }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Lession> Lessons { get; set; }  
        public DbSet<ResourcesFile> ResourcesFiles { get; set; }  
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<SubjectNotification> SubjectNotifications { get; set; }
        public DbSet<Class> Classs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lession>()
            .HasOne(sub=>sub.Subject)
            .WithMany(l=>l.Lession)
            .HasForeignKey(l=>l.subjectId);

            modelBuilder.Entity<ResourcesFile>()
          .HasOne(l=>l.lession)
          .WithMany(lf=>lf.LessonsFile)
          .HasForeignKey(lf=>lf.LessionId);

            modelBuilder.Entity<Question>()
          .HasOne(l=>l.lession)
          .WithMany(q=>q.Question)
          .HasForeignKey(q=>q.LessionId);

            modelBuilder.Entity<Answer>()
          .HasOne(q=>q.Question)
          .WithMany(a=>a.Answers)
          .HasForeignKey(a=>a.QuestionId);

            modelBuilder.Entity<SubjectNotification>()
         .HasOne(s=>s.Subject)
         .WithMany(a => a.SubjectNotification)
         .HasForeignKey(a => a.SubjectId);
            modelBuilder.Entity<Class>()
       .HasOne(s=>s.Subject)
       .WithMany(c=>c.Class)
       .HasForeignKey(c=>c.Subjectid);
        }

    

}
}
