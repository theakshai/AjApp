using Microsoft.EntityFrameworkCore;
using AjApp.Models;
namespace AjApp.Data
{
    public class AuthUserContext : DbContext
    {

        public AuthUserContext(DbContextOptions<AuthUserContext> options)  :base(options){ } 

        public DbSet<Auth> Auth { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
