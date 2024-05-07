using System.ComponentModel.DataAnnotations;

namespace UsersAuthAPI.Data.DTOs
{
    public class CreateUserDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
