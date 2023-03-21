using HelsiTest.Common.Exceptions;
using HelsiTest.Core.Entities;
using HelsiTest.Core.Repositories;
using HelsiTest.Infrastructure.DataAccess.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HelsiTest.Infrastructure.DataAccess.Repositories.Implementations
{
    public class ListRepository : IListRepository
    {
        private readonly ApplicationDbContext _context;
        public ListRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        private async Task CheckUserExistAsync(int userID)
        {
            var result = await _context.Users.AnyAsync(x => x.Id == userID);
            if (!result)
            {
                throw new ObjectNotFoundException($"There are no user with ID - {userID}");
            }
        }

        public async Task<bool> CheckPermisstionAsync(int listId, int currentUserId)
        {
            await CheckUserExistAsync(currentUserId);
            var result = await _context.UserLists.AnyAsync(x => x.UserId == currentUserId && x.Id == listId);
            if (!result)
            {
                throw new PermissionDeniedException($"Permission Denied for UserId - {currentUserId}");
            }
            return result;
        }

        public async Task<bool> AddAccessToListAsync(int listId, int userId, int currentUserId)
        {
            await CheckUserExistAsync(currentUserId);
            var user = await _context.Users.FirstAsync(x => x.Id == userId);
            var list = await _context.Lists.FirstAsync(x => x.Id == listId);
            _context.UserLists.Add(new UserListEntity
            {
                List = list,
                User = user,
            });
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> AddItemToListAsync(ItemEntity item, int currentUserId)
        {
            await CheckUserExistAsync(currentUserId);
            var list = await _context.Lists.FirstAsync(x => x.Id == item.ListId);
            var result = _context.Items.Add(new ItemEntity
            {
                List = list,
                Text = item.Text,
            });

            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<PaginationModel<ListEntity>> GetListsForUserAsync(int currentUserId, int currentPage = 1, int pageSize = 5)
        {
            await CheckUserExistAsync(currentUserId);

            var totalItems = await _context.UserLists.Where(x => x.User.Id == currentUserId).CountAsync();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            int startIndex = (currentPage - 1) * pageSize;
            int endIndex = Math.Min(startIndex + pageSize, totalItems);

            var lists = await _context.UserLists.Where(x => x.User.Id == currentUserId).Include(x => x.List).Select(x => x.List).Skip(startIndex).Take(endIndex).ToListAsync();
            var result = new PaginationModel<ListEntity>
            {
                Items = lists,
                PageNum = currentPage,
                ItemsOnPage = pageSize,
                TotalPages = totalPages,
            };
            return result;
        }

        public async Task RemoveItemFromListAsync(int listId, int itemId, int currentUserId)
        {
            await CheckUserExistAsync(currentUserId);
            var itemToRemove = await _context.Items.FirstAsync(x => x.Id == itemId);
            _context.Items.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }

        public async Task<int> AddNewListAsync(ListEntity listEntity, int currentUserId)
        {
            await CheckUserExistAsync(currentUserId);
            listEntity.OwnerId = currentUserId;
            var result = _context.UserLists.Add(new UserListEntity
            {
                List = listEntity,
                UserId = currentUserId,
            });
            await _context.SaveChangesAsync();
            return result.Entity.List.Id;
        }

        public async Task<int> UpdateListAsync(ListEntity listEntity, int currentUserId)
        {
            await CheckUserExistAsync(currentUserId);
            var result = _context.Lists.Update(listEntity);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }
        public async Task RemoveListAsync(int listId, int currentUserId) 
        {
            await CheckUserExistAsync(currentUserId);

            var itemToRemove = await _context.Lists.FirstAsync(x => x.Id == listId);

            _context.Lists.Remove(itemToRemove);
            await _context.SaveChangesAsync();
        }

        public async Task<ListEntity> GetListAsync(int listId, int currentUserId)
        {
            await CheckUserExistAsync(currentUserId);

            var listItem = await _context.Lists.Include(x => x.Items.OrderByDescending(x => x.CreatedAt)).FirstAsync(x => x.Id == listId);
            return listItem;
        }

        public async Task<PaginationModel<UserEntity>> GetUsersForListAsync(int listId, int currentUserId, int currentPage = 1, int pageSize = 5)
        {
            await CheckUserExistAsync(currentUserId);

            var totalItems = await _context.UserLists.CountAsync(x => x.List.Id == listId);
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            int startIndex = (currentPage - 1) * pageSize;
            int endIndex = Math.Min(startIndex + pageSize, totalItems);

            var lists = await _context.UserLists.Where(x => x.List.Id == listId).Include(x => x.User).Select(x => x.User).Skip(startIndex).Take(endIndex).ToListAsync();
            var result = new PaginationModel<UserEntity>
            {
                Items = lists,
                PageNum = currentPage,
                ItemsOnPage = pageSize,
                TotalPages = totalPages,
            };
            return result;
        }
    }
}
