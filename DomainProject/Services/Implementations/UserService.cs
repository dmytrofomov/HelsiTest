using HelsiTest.Core.Entities;
using HelsiTest.Core.Repositories;
using HelsiTest.Core.Services;
using Microsoft.Extensions.Logging;

namespace HelsiTest.Core.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _userRepo;
        public UserService(ILogger<UserService> logger, IUserRepository userRepo)
        {
            _logger = logger;
            _userRepo = userRepo;
        }

        public async Task<int> AddUserAsync(UserEntity entity)
        {
            _logger.LogInformation("Add new user");
            return await _userRepo.AddUserAsync(entity);
        }

        public async Task<UserEntity> GetUserByIdAsync(int id)
        {
            _logger.LogInformation("Get user by id");
            return await _userRepo.GetUserByIdAsync(id);
        }

        public async Task<UserEntity> GetUserByNameAsync(string name)
        {
            _logger.LogInformation("Get user by name");
            return await _userRepo.GetUserByNameAsync(name);
        }
    }
}
