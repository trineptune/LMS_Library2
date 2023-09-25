using UserWebApi.Models;

namespace UserWebApi.Repository
{
    public interface IUser
    {
        Task<IEnumerable<User>> GetUsers();
        List<User> SearchUsers(string key);
        Task<User> AddUser(UserDTO userDTO);
        Task<bool> UpdateUser(int id,UserDTO userDTO);
        Task<bool> DeleteUser(int id);
        Task<User> GetUserById(int id);
        void UpdateUserAuthentication(int userId);
        Task<bool> ChangePassword(int userId, string currentPassword, string newPassword);
        void AddOrUpdateAvatar(int userId, string avatarPath);
        void RemoveAvatar(int userId);
    }
}
