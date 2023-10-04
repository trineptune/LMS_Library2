using ExamWebApi.Data;
using ExamWebApi.DTO;
using ExamWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamWebApi.Repository
{
    public class ExamRepository:IExamRepository
    {
        private readonly ExamDbContext _context;
        public ExamRepository(ExamDbContext context)
        {
            _context = context;
        }
        public async Task<List<Exam>> GetAllExams()
        {
            return await _context.Exams.ToListAsync();
        }
        public async Task<List<Exam>> GetUnapprovedExam()
        {
            return await _context.Exams.Where(rf => !rf.approve).ToListAsync();
        }
        public async Task<List<Exam>> GetapprovedExam()
        {
            return await _context.Exams.Where(rf => rf.approve).ToListAsync();
        }
        public async Task<Exam> GetExambyId(int id)
        {
            return await _context.Exams.FindAsync(id);
        }
        public async Task AddExam(ExamDTO examdto)
        {
            examdto.approve = false; // Mặc định là chưa được phê duyệt
            var newExam = new Exam
            {
                Title= examdto.Title,
                approve= examdto.approve,
                SubjectId= examdto.SubjectId,
                UserId= examdto.UserId,
                type = examdto.type,
                time = examdto.time
            };
            _context.Exams.Add(newExam);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateExam(int id, ExamDTO examdto)
        {
            var exam = await _context.Exams.FindAsync(id);

            if (exam == null)
            {
                return false;
            }
            exam.time = examdto.time;
            exam.Title = examdto.Title;
            exam.SubjectId = examdto.SubjectId;
            exam.UserId = examdto.UserId;
            exam.approve = examdto.approve;
            exam.type= examdto.type;

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteExam(int id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
            {
                return false;
            }

            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task ApproveExam(int id)
        {
            var exam = await GetExambyId(id);
            if (exam != null)
            {
                exam.approve = true;
                _context.Exams.Update(exam);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DisapproveExam(int id)
        {
            var exam = await GetExambyId(id);
            if (exam != null)
            {
                exam.approve = false;
                _context.Exams.Update(exam);
                await _context.SaveChangesAsync();
            }
        }
    }
}
