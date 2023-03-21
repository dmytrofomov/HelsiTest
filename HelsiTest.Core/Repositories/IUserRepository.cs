using HelsiTest.Core.Entities;

namespace HelsiTest.Core.Repositories
{
    public interface IUserRepository
    {
        Task<int> AddUserAsync(UserEntity user);
        Task<UserEntity> GetUserByIdAsync(int userId);
        Task<UserEntity> GetUserByNameAsync(string name);

    }
}
