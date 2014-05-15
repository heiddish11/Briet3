using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Briet3.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class AppDataContext : IdentityDbContext<ApplicationUser>
    {
        public AppDataContext()
            : base("AppDataContext")
        {
        }
        //Setting every modelclass into the Database, to create a list in the database.
        public DbSet<Title> Titles { get; set; }
        public DbSet<FileSRT> Files { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}