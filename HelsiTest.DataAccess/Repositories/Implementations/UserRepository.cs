using HelsiTest.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using HelsiTest.Core.Entities;
using HelsiTest.Infrastructure.DataAccess.DatabaseContext;
using HelsiTest.Common.Exceptions;
using System.Collections.Generic;

namespace HelsiTest.Infrastructure.DataAccess.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddUserAsync(UserEntity user)
        {
            var u = _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return u.Entity.Id;
        }

        public async Task<UserEntity> GetUserByIdAsync(int userId) => await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

        public async Task<UserEntity> GetUserByNameAsync(string name) =>  await _context.Users.FirstOrDefaultAsync(x => x.Name == name);
    }
}
