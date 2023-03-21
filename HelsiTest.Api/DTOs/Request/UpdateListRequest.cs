using System.ComponentModel.DataAnnotations;

namespace HelsiTest.Api.DTOs.Request
{
    public class UpdateListRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
