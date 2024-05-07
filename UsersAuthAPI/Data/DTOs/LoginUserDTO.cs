using System.ComponentModel.DataAnnotations;

namespace UsersAuthAPI.Data.DTOs
{
    public class LoginUserDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
