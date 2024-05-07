using UsersAuthAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UsersAuthAPI.Data
{
    public class UserDbContext : IdentityDbContext<User>
    {
        public UserDbContext
            (DbContextOptions<UserDbContext> opts) : base(opts) { }
    }
}
