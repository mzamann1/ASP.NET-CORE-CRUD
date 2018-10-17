using Microsoft.EntityFrameworkCore;
namespace MVA_Beginner_Razor_CRUD
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}