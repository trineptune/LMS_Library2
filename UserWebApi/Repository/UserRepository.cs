using Microsoft.EntityFrameworkCore;
using UserWebApi.Data;
using UserWebApi.Models;

namespace UserWebApi.Repository
{
    public class UserRepository:IUser
    {
        private readonly UserDbContext _context;
        public UserRepository(UserDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<User> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
       
    }
}
