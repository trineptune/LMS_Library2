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
        void UpdateUserAuthentication(int userId, string refreshToken, DateTime tokenCreated, DateTime tokenExpires);
    }
}
