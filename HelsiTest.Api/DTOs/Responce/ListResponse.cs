using HelsiTest.Core.Entities;

namespace HelsiTest.Api.DTOs.Responce
{
    public class ListResponse
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int OwnerId { get; set; }

        public string Name { get; set; }

        public List<ItemResponse> Items { get; set; }

    }
}
