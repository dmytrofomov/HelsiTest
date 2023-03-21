using HelsiTest.Core.Entities;
using HelsiTest.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace HelsiTest.Core.Services.Implementations
{
    public class ListService : IListService
    {
        private readonly ILogger<ListService> _logger;
        private readonly IListRepository _listRepo;

        public ListService(ILogger<ListService> logger, IListRepository listRepo)
        {
            _logger = logger;
            _listRepo = listRepo;
        }

        public async Task<bool> AddAccessToListAsync(int listId, int userId, int currentUserId)
        {
            await _listRepo.CheckPermisstionAsync(listId, currentUserId);

            var result = await _listRepo.AddAccessToListAsync(listId, userId, currentUserId);
            return result;
        }

        public async Task<int> AddItemToListAsync(ItemEntity item, int currentUserId)
        {
            await _listRepo.CheckPermisstionAsync(item.ListId, currentUserId);

            var result = await _listRepo.AddItemToListAsync(item, currentUserId);
            return result;
        }

        public async Task<int> AddNewListAsync(ListEntity listEntity, int currentUserId)
        {
            var result = await _listRepo.AddNewListAsync(listEntity, currentUserId);
            return result;
        }

        public async Task<int> UpdateListAsync(ListEntity listEntity, int currentUserId)
        {
            await _listRepo.CheckPermisstionAsync(listEntity.Id, currentUserId);
            return await _listRepo.UpdateListAsync(listEntity, currentUserId);
        }

        public async Task RemoveListAsync(int listId, int currentUserId)
        {
            await _listRepo.CheckPermisstionAsync(listId, currentUserId);

            await _listRepo.RemoveListAsync(listId, currentUserId);
        }


        public async Task<ListEntity> GetListAsync(int listId, int currentUserId)
        {
            await _listRepo.CheckPermisstionAsync(listId, currentUserId);
            var result = await _listRepo.GetListAsync(listId, currentUserId);
            return result;
        }

        public async Task<PaginationModel<ListEntity>> GetListsForUserAsync(int currentUserId, int currentPage = 1, int pageSize = 5)
        {
            var result = await _listRepo.GetListsForUserAsync(currentUserId, currentPage, pageSize);
            return result;
        }


        public async Task<PaginationModel<UserEntity>> GetUsersForListAsync(int listId, int currentUserId, int currentPage = 1, int pageSize = 5)
        {
            var result = await _listRepo.GetUsersForListAsync(listId, currentUserId, currentPage, pageSize);

            return result;
        }

        public async Task RemoveItemFromListAsync(int listId, int itemId, int currentUserId)
        {
            await _listRepo.CheckPermisstionAsync(listId, currentUserId);

            await _listRepo.RemoveItemFromListAsync(listId, itemId, currentUserId);

        }


    }
}
