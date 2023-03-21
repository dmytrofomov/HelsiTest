using System.ComponentModel.DataAnnotations;

namespace HelsiTest.Api.DTOs.Request
{
    public class AddUserRequest
    {
        [Required]
        [MinLength(1)]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
