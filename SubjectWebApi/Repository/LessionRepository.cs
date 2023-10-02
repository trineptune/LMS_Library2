using Microsoft.EntityFrameworkCore;
using SubjectWebApi.Data;
using SubjectWebApi.DTO;
using SubjectWebApi.Models;

namespace SubjectWebApi.Repository
{
    public class LessionRepository:ILessionRepository
    {
        private readonly SubjectDbContext _context;
        public LessionRepository(SubjectDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Lession>> GetAllLessions()
        {
            return await _context.Lessons.ToListAsync();
        }
        public async Task<List<Lession>> GetapprovedLession()
        {
            return await _context.Lessons.Where(rf => rf.Approve).ToListAsync();
        }
        public async Task<List<Lession>> GetUnapprovedLession()
        {
            return await _context.Lessons.Where(rf => !rf.Approve).ToListAsync();
        }
        public async Task<Lession> GetLessionById(int id)
        {
            return await _context.Lessons.FindAsync(id);
        }

        public async Task<LessionDTO> AddLession(LessionDTO lessiondto)
        {
            var newLession = new Lession
            {
                Description = lessiondto.Description,
                subjectId = lessiondto.subjectId,
                LessonName = lessiondto.LessonName,

            };
            _context.Lessons.Add(newLession);
            await _context.SaveChangesAsync();

            return lessiondto;
        }

        public async Task<bool> UpdateLession(int id, LessionDTO lessiondto)
        {
            var Lession = await _context.Lessons.FindAsync(id);

            if (Lession == null)
            {
                return false;
            }

            Lession.Description = lessiondto.Description;
            Lession.LessonName = lessiondto.LessonName;
            lessiondto.subjectId = lessiondto.subjectId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteLession(int id)
        {
            var Lession = await _context.Lessons.FindAsync(id);
            if (Lession == null)
            {
                return false;
            }

            _context.Lessons.Remove(Lession);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task ApproveResourcesFile(int id)
        {
            var lession = await GetLessionById(id);
            if (lession != null)
            {
                lession.Approve = true;
                _context.Lessons.Update(lession);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DisapproveResourcesFile(int id)
        {
            var lession = await GetLessionById(id);
            if (lession != null)
            {
                lession.Approve = false;
                _context.Lessons.Update(lession);
                await _context.SaveChangesAsync();
            }
        }
    }
}
