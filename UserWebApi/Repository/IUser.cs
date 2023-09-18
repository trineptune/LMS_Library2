using UserWebApi.Models;

namespace UserWebApi.Repository
{
    public interface IUser
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<User> AddUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
    }
}
