using HelsiTest.Core.Entities;

namespace HelsiTest.Core.Services
{
    public interface IListService
    {
        Task<PaginationModel<ListEntity>> GetListsForUserAsync(int currentUserId, int currentPage = 1, int pageSize = 5);
        Task<PaginationModel<UserEntity>> GetUsersForListAsync(int listId, int currentUserId, int currentPage = 1, int pageSize = 5);
        Task<int> AddNewListAsync(ListEntity listEntity, int currentUserId);
        Task<int> UpdateListAsync(ListEntity listEntity, int currentUserId);
        Task<ListEntity> GetListAsync(int listId, int currentUserId);
        Task RemoveListAsync(int listId, int currentUserId);
        Task<int> AddItemToListAsync(ItemEntity item, int currentUserId);
        Task RemoveItemFromListAsync(int listId, int itemId, int currentUserId);
        Task<bool> AddAccessToListAsync(int listId, int userId, int currentUserId);
    }
}
