using HelsiTest.Core.Entities;
using System.Text.Json.Serialization;

namespace HelsiTest.Core.Entities
{
    public class ItemEntity : BaseEntity
    {

        public int? Priority { get; set; }
        public int ListId { get; set; }

        public string Text { get; set; }

        [JsonIgnore]
        public ListEntity List { get; set; }
    }
}
