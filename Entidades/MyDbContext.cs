using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        //public DbSet<User> Users { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Client> Clients { get; set; } = default!;
        public DbSet<Purchase> Purchases { get; set; } = default!;
        public DbSet<PurchaseDetail> PurchaseDetails { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Purchase>()
                .HasKey(pp => new { pp.Id, pp.ProductId });

            
        }
    }







}
