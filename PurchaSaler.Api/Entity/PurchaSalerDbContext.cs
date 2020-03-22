using Microsoft.EntityFrameworkCore;

namespace PurchaSaler.Api.Entity
{
    public class PurchaSalerDbContext:DbContext
    {
        public PurchaSalerDbContext(DbContextOptions<PurchaSalerDbContext> options):
            base(options)
        {

        }

        public DbSet<Users> Users { set; get; }
    }
}
