using Microsoft.AspNetCore.Identity;

namespace UsersAuthAPI.Models
{
    public class User : IdentityUser
    {
        public DateTime BirthDate { get; set; }

        public User (): base () { }
    }
}
