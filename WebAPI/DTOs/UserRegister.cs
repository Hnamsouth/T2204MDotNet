using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs
{
    public class UserRegister
    {
        public int Id { get; set; }
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
