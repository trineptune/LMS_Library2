using Azure;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using UserWebApi.Models;
using UserWebApi.Repository;

namespace UserWebApi.Service
{
    public class RefreshTokenService:IRefreshToken
    {
        private readonly IUser _userRepository;
        public RefreshTokenService(IUser userRepository)
        {
            _userRepository = userRepository;
        }
        public void SetRefreshToken(int userId)
        {
            _userRepository.UpdateUserAuthentication(userId);
        }
    }
}
