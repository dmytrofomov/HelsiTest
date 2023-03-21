using HelsiTest.Core.Entities;

namespace HelsiTest.Core.Services
{
    public interface IUserService
    {
        Task<int> AddUserAsync(UserEntity entity);
        Task<UserEntity> GetUserByIdAsync(int id);
        Task<UserEntity> GetUserByNameAsync(string name);

    }
}
