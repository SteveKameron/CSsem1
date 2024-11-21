using Microsoft.EntityFrameworkCore;

namespace NorthwindAPI.Models
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions<NorthwindContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
    
}
