using Microsoft.EntityFrameworkCore;
using PurchaSaler.Domain.Entities;

namespace PurchaSaler.Infrastructure.ORM
{
    public class PurchaSalerDbContext : DbContext
    {
        public PurchaSalerDbContext(DbContextOptions<PurchaSalerDbContext> options) :
            base(options)
        {

        }

        public DbSet<Users> Users { set; get; }
        public DbSet<Products> Products { set; get; }
        public DbSet<ProductType> ProductTypes { set; get; }
        public DbSet<ShoppingCarts> ShoppingCarts { get; set; }

    }
}
