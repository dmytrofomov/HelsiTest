using HelsiTest.Core.Entities;
using System.Text.Json.Serialization;

namespace HelsiTest.Api.DTOs.Responce
{
    public class ItemResponse
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? Priority { get; set; }
        public int ListId { get; set; }

        public string Text { get; set; }

    }
}
