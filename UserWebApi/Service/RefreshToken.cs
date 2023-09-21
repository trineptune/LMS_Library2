using Microsoft.Identity.Client;
using UserWebApi.Models;
using UserWebApi.Repository;
using IUser = UserWebApi.Repository.IUser;

namespace UserWebApi.Service
{
    public class RefreshToken: IRefreshToken
    {
        public readonly IUser _userRepository;

        public RefreshToken(IUser userRepository)
        {
            _userRepository = userRepository;
        }
        public void SetRefresh(int userId, User user)
        {
            _userRepository.UpdateUserAuthentication(userId, user.RefreshToken,user.TokenCreated, user.TokenExpires);
        }
    }
}
