using Microsoft.EntityFrameworkCore;
using SubjectWebApi.Models;
using UserWebApi.Data;
using UserWebApi.Models;

namespace SubjectWebApi.Data
{
    public class SubjectDbContext: DbContext
    {
        public SubjectDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Lesson> Lessons { get; set; }  
        public DbSet<LessonFile> LessonsFile { get; set; }  
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lesson>()
            .HasOne(sub=>sub.Subject)
            .WithMany(l=>l.Lession)
            .HasForeignKey(l=>l.subjectId);

            modelBuilder.Entity<LessonFile>()
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
          .HasForeignKey(a=>a.Question);
        }
       
    }
}
