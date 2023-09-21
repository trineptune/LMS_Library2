using UserWebApi.Models;

namespace UserWebApi.Service
{
    public interface IRefreshToken
    {
        public void SetRefresh(int userId, User user);
    }
}
