using HelsiTest.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HelsiTest.Core.Entities
{
    public class ListEntity : BaseEntity
    {

        public int OwnerId { get; set; }

        public string Name { get; set; }

        public List<ItemEntity> Items { get; set; }

        [JsonIgnore]
        public List<UserListEntity> ListUsers { get; set; }

    }
}
