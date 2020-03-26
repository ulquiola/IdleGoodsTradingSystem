using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PurchaSaler.Models;

namespace PurchaSaler.DAL
{
    public class SqlProducts
    {
        private readonly PurchaSalerDbContext _db;
        public SqlProducts(PurchaSalerDbContext db)
        {
            _db = db;
        }

        public List<Products> GetProductsAll()
        {
            var products = (from p in _db.Products
                            select p).ToList();
            return products;
        }

        public List<Products> GetProductsByType(Guid typid)
        {
            var products = _db.Products.Where(p => p.ProductTypeID == typid);
            return products.ToList();
        }
    }
}
