using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using UserWebApi.Data;
using UserWebApi.Models;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

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
        public List<User> SearchUsers(string key)
        {
            var users = _context.Users
    .AsEnumerable()
    .Where(u => u.Username.Contains(key, StringComparison.OrdinalIgnoreCase) || u.UserCode.Contains(key, StringComparison.OrdinalIgnoreCase))
    .ToList();
            return users;
        }
       
        public async Task<User> AddUser(UserDTO userdto)
        {
            var newUser = new User
            {
                Address = userdto.Address,
                Email = userdto.Email,
                Gender = userdto.Gender,
                UserCode = userdto.UserCode,
                Sector = userdto.Sector,
                Password = userdto.Password,
                Phone = userdto.Phone,
                RoleId = userdto.RoleId,
                Username = userdto.Username
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<bool> UpdateUser(int id, UserDTO userDTO)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return false;
            }
            user.Username= userDTO.Username;
            user.Email= userDTO.Email;
            user.Gender= userDTO.Gender;
            user.Sector= userDTO.Sector;
            user.Password= userDTO.Password;
            user.Phone= userDTO.Phone;
            user.RoleId= userDTO.RoleId;
            user.UserCode= userDTO.UserCode;
            user.Sector= userDTO.Sector;
            
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
        public void UpdateUserAuthentication(int userId)
        {
            // Lấy thông tin người dùng từ cơ sở dữ liệu
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            if (user != null)
            {
                // Cập nhật thông tin xác thực của người dùng
                user.RefreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
                user.TokenCreated = DateTime.Now;
                user.TokenExpires = DateTime.Now.AddDays(1);

                _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }
        }
        public async Task<bool> ChangePassword(int userId, string currentPassword, string newPassword)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return false;
            }

            if (user.Password != currentPassword)
            {
                return false;
            }

            user.Password = newPassword;
            await _context.SaveChangesAsync();

            return true;
        }

        public void AddOrUpdateAvatar(int userId, string avatarPath)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                user.AvatarPath = avatarPath;
                _context.SaveChanges();
            }
        }

        public void RemoveAvatar(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                user.AvatarPath = "";
                _context.SaveChanges();
            }
        }
    }
}
