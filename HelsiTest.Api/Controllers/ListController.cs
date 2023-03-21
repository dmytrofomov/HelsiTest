using AutoMapper;
using HelsiTest.Api.DTOs.Request;
using HelsiTest.Api.DTOs.Responce;
using HelsiTest.Core.Entities;
using HelsiTest.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelsiTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListController : ControllerBase
    {
        private readonly IListService _listService;
        private readonly IMapper _mapper;

        public ListController(IListService listService, IMapper mapper)
        {
            _mapper = mapper;
            _listService = listService;
        }

        [HttpGet(template: "/{currentPage}/{pageSize}/{currentUserId}")]
        public async Task<PaginationModel<ListResponse>> GetListsForUser(int currentUserId, int currentPage = 1, int pageSize = 5)
        {
            var result = await _listService.GetListsForUserAsync(currentUserId, currentPage, pageSize);
            return new PaginationModel<ListResponse>
            {
                Items = result.Items.Select(x => _mapper.Map<ListResponse>(x)).ToList(),
                TotalPages = result.TotalPages,
                ItemsOnPage = result.ItemsOnPage,
                PageNum = result.PageNum
            };
        }

        [HttpGet(template: "/{listId}/{currentUserId}")]
        public async Task<ListResponse> GetList(int listId, int currentUserId)
        {
            var result = await _listService.GetListAsync(listId, currentUserId);
            var mappedEntity = _mapper.Map<ListResponse>(result);
            return mappedEntity;
        }

        [HttpPost(template: "/{currentUserId}")]
        public async Task<int> AddList([FromBody] AddListRequest addListDto, int currentUserId)
        {
            var mappedEntity = _mapper.Map<ListEntity>(addListDto);
            return await _listService.AddNewListAsync(mappedEntity, currentUserId);
        }

        [HttpPut(template: "/{currentUserId}")]
        public async Task<int> UpdateList([FromBody] AddListRequest addListDto, int currentUserId)
        {
            var mappedEntity = _mapper.Map<ListEntity>(addListDto);
            return await _listService.UpdateListAsync(mappedEntity, currentUserId);
        }

        [HttpDelete(template: "/{listId}/{currentUserId}")]
        public async Task RemoveList(int listId, int currentUserId)
        {
            await _listService.RemoveListAsync(listId, currentUserId);
        }

        [HttpPut(template: "/{listId}/add-access/{userId}/{currentUserId}")]
        public async Task<bool> AddAccessToList(int listId, int userId, int currentUserId)
        {
            return await _listService.AddAccessToListAsync(listId, userId, currentUserId);
        }

        [HttpPost(template: "/item/{currentUserId}")]
        public async Task<int> AddItemToList([FromBody] AddListRequest addItemDto, int currentUserId)
        {
            var mappedEntity = _mapper.Map<ItemEntity>(addItemDto);
            return await _listService.AddItemToListAsync(mappedEntity, currentUserId);
        }

        [HttpDelete(template: "{listId}/item/{itemId}/{currentUserId}")]
        public async Task RemoveItemFromList(int listId, int itemId, int currentUserId)
        {
            await _listService.RemoveItemFromListAsync(listId, itemId, currentUserId);
        }
    }
}
