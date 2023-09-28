using Microsoft.EntityFrameworkCore;
using SubjectWebApi.Data;
using SubjectWebApi.DTO;
using SubjectWebApi.Models;

namespace SubjectWebApi.Repository
{
    public class ClassRepository:IClassrepository
    {
        private readonly SubjectDbContext _context;
        public ClassRepository(SubjectDbContext context)
        {
            _context = context;
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
    }
}
