using ExamWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamWebApi.Data
{
    public class ExamDbContext : DbContext
    {
        public ExamDbContext(DbContextOptions<ExamDbContext> options) : base(options)
        {

        }
        public DbSet<EssayExam> EssayExams { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamContent> ExamContents { get; set; }
        public DbSet<ExamAnswer> ExamAnswers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EssayExam>()
           .HasOne(e=>e.Exam)
           .WithMany(es=>es.EssayExam)
           .HasForeignKey(es=>es.ExamId);

            modelBuilder.Entity<ExamContent>()
           .HasOne(e => e.Exam)
           .WithMany(ec=>ec.ExamContent)
           .HasForeignKey(es => es.ExamId);

            modelBuilder.Entity<ExamAnswer>()
           .HasOne(e => e.ExamContent)
           .WithMany(a=>a.ExamAnswer)
           .HasForeignKey(a=>a.QuestionId);
        }

    }
}
