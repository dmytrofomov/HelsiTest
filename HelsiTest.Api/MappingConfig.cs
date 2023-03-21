using AutoMapper;
using HelsiTest.Api.DTOs.Request;
using HelsiTest.Api.DTOs.Responce;
using HelsiTest.Core.Entities;

namespace HelsiTest.Api
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapConfig = new MapperConfiguration(c =>
            {
                c.CreateMap<AddUserRequest, UserEntity>();
                c.CreateMap<AddListRequest, ListEntity>();
                c.CreateMap<UpdateListRequest, ListEntity>();
                c.CreateMap<AddItemRequest, ItemEntity>();

                c.CreateMap<UserEntity, UserResponse>();
                c.CreateMap<ListEntity, ListResponse>();
                c.CreateMap<ItemEntity, ItemResponse>();
            });
            return mapConfig;
        }
    }
}
