using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SubjectWebApi.Data;
using SubjectWebApi.DTO;
using SubjectWebApi.Models;
namespace SubjectWebApi.Repository
{
    public class ClassRepository:IClassrepository
    {
        private readonly SubjectDbContext _context;
        private readonly ISubjectRepository _repository;
        public ClassRepository(SubjectDbContext context, ISubjectRepository repository)
        {
            _context = context;
            _repository = repository;
        }
        public async Task<IEnumerable<Class>> GetAllClass()
        {
            return await _context.Classs.ToListAsync();
        }

        public async Task<Class> GetClassById(int id)
        {
            return await _context.Classs.FindAsync(id);
        }

        public async Task<ClassDTO> AddClass(ClassDTO classdto)
        {
            var newclass = new Class
            {
                userId = classdto.userId,
                Subjectid = classdto.Subjectid,


            };
            _context.Classs.Add(newclass);
            await _context.SaveChangesAsync();

            return classdto;
        }

        public async Task<bool> UpdateClass(int id, ClassDTO classdto)
        {
            var updateclass = await _context.Classs.FindAsync(id);

            if (updateclass == null)
            {
                return false;
            }

           updateclass.Subjectid = classdto.Subjectid;
            updateclass.userId = classdto.userId;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteClass(int id)
        {
            var xClass = await _context.Classs.FindAsync(id);
            if (xClass == null)
            {
                return false;
            }

            _context.Classs.Remove(xClass);
            await _context.SaveChangesAsync();
            return true;
        }
        public List<Subject> GetSubjectsByUserId(int userId)
        {
            var subjects = _context.Classs
                .Where(c => c.userId == userId)
                .Select(c => c.Subject)
                .ToList();

            return subjects;
        }
        public List<Subject> GetSubjectsByName(int userId,string SubjectName)
        {
            var Subject = _context.Subjects
            .AsEnumerable()
            .Where(u => u.SubjectName.Contains(SubjectName, StringComparison.OrdinalIgnoreCase))
            .ToList();
            return Subject;
        }
    
        public List<Subject> GetSubjectFavorate(int userId)
        {
            var subjects = _context.Classs
         .Where(c => c.userId == userId && c.Subject.star==true)
         .Select(c => c.Subject)
         .ToList();

            return subjects;
        }
        public async Task TickStartSubject(int UserId,int SubjectId)
        {
            var subject = GetSubjectsByUserId(UserId);
            if (subject != null)
            {
                var sub=await _repository.GetSubjectById(SubjectId);
                if (sub != null)
                {
                    sub.star = true;
                    await _context.SaveChangesAsync();
                }
            }
        }
        public async Task DisTickStartSubject(int UserId, int SubjectId)
        {
            var subject = GetSubjectsByUserId(UserId);
            if (subject != null)
            {
                var sub = await _repository.GetSubjectById(SubjectId);
                if (sub != null)
                {
                    sub.star = false;
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
