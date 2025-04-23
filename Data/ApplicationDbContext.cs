using Microsoft.EntityFrameworkCore;
using KlarityMVP.Models;

namespace KlarityMVP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
