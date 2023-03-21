using System.ComponentModel.DataAnnotations;

namespace HelsiTest.Api.DTOs.Request
{
    public class AddItemRequest
    {
        [Required]
        public int ListId { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(500)]
        public string Text { get; set; }
    }
}
