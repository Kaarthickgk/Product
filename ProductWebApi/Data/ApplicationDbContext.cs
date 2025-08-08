using Microsoft.EntityFrameworkCore;
using ProductWebApi.Model;

namespace ProductWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {

      
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
                
        }

        public DbSet<Product> Products { get; set; }
    }
}
