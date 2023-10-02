using Microsoft.EntityFrameworkCore;
using SubjectWebApi.Data;
using SubjectWebApi.DTO;
using SubjectWebApi.Models;


namespace SubjectWebApi.Repository
{
    public class SubjectRepository:ISubjectRepository
    {
        private readonly SubjectDbContext _context;
        public SubjectRepository(SubjectDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Subject>> GetAllSubjects()
        {
            return await _context.Subjects.ToListAsync();
        }

        public async Task<Subject> GetSubjectById(int id)
        {
            return await _context.Subjects.FindAsync(id);
        }

        public async Task<SubjectDTO> AddSubject(SubjectDTO subjectDto)
        {
            var newSubject = new Subject
            {
                Description = subjectDto.Description,
                SubjectName = subjectDto.SubjectName,
                UserId = subjectDto.Userid,
                

            };
            _context.Subjects.Add(newSubject);
            await _context.SaveChangesAsync();

            return subjectDto;
        }

        public async Task<bool> UpdateSubject(int id, SubjectDTO subjectdto)
        {
            var subject = await _context.Subjects.FindAsync(id);

            if (subject == null)
            {
                return false;
            }

            subject.SubjectName = subjectdto.SubjectName;
            subject.UserId = subjectdto.Userid;
            subject.Description = subjectdto.Description;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteSubject(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
            {
                return false;
            }

            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
