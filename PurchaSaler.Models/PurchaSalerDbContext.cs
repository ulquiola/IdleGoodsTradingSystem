using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PurchaSaler.Models
{
    public class PurchaSalerDbContext:DbContext
    {
        public PurchaSalerDbContext(DbContextOptions<PurchaSalerDbContext> options) :
            base(options)
        {

        }

        public DbSet<Users> Users { set; get; }
        public DbSet<Products> Products { set; get; }
        public DbSet<ProductType> ProductTypes { set; get; }
    }
}
