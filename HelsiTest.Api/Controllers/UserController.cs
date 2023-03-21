using AutoMapper;
using HelsiTest.Api.DTOs.Request;
using HelsiTest.Api.DTOs.Responce;
using HelsiTest.Core.Entities;
using HelsiTest.Core.Services;
using HelsiTest.Core.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace HelsiTest.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IListService _listService;

        public UserController(ILogger<UserController> logger, IUserService userService, IListService listService, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _userService = userService;
            _listService = listService;
        }

        [HttpPost]
        public async Task<int> AddUser([FromBody] AddUserRequest dto)
        {
            var mappedEntity = _mapper.Map<UserEntity>(dto);
            return await _userService.AddUserAsync(mappedEntity);
        }

        [HttpGet(template: "/list/{listId}/{currentPage}/{pageSize}/{currentUserId}")]
        public async Task<PaginationModel<UserResponse>> GetUsersForList(int listId, int currentUserId, int currentPage = 1, int pageSize = 5)
        {
            var result =  await _listService.GetUsersForListAsync(listId, currentUserId, currentPage, pageSize);
            return new PaginationModel<UserResponse>
            {
                Items = result.Items.Select(x => _mapper.Map<UserResponse>(x)).ToList(),
                TotalPages= result.TotalPages,
                ItemsOnPage= result.ItemsOnPage,
                PageNum= result.PageNum
            };
        }

        [HttpGet(template: "/{userId:int}")]
        public async Task<UserResponse> GetUserById(int userId)
        {
            var result = await _userService.GetUserByIdAsync(userId);
            var mappedEntity = _mapper.Map<UserResponse>(result);
            return mappedEntity;
        }

        [HttpGet(template: "/{userName}")]
        public async Task<UserResponse> GetUserByName(string userName)
        {
            var result = await _userService.GetUserByNameAsync(userName);
            var mappedEntity = _mapper.Map<UserResponse>(result);
            return mappedEntity;
        }
    }
}
