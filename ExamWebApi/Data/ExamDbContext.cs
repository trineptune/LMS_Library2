using ExamWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamWebApi.Data
{
    public class ExamDbContext: DbContext
    {
        public ExamDbContext(DbContextOptions<ExamDbContext> options) : base(options)
        {

        }
        public DbSet<EssayExam> EssayExams { get; set; }
        public DbSet<Exam> Exams { get; set; }  
        public DbSet<ExamContent> ExamContents { get; set; }
        public DbSet<ExamAnswer> ExamAnswers { get; set; }
    }
}
