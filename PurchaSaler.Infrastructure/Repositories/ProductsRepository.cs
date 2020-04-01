using PurchaSaler.Domain.Entities;
using PurchaSaler.Domain.IRepositories;
using PurchaSaler.Infrastructure.ORM;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PurchaSaler.Infrastructure.Repositories
{
    public class ProductsRepository:IProductsRepository
    {
        private readonly PurchaSalerDbContext _db;

        public ProductsRepository(PurchaSalerDbContext db)
        {
            _db = db;
        }
        public List<Products> GetAllProducts()
        {
            var products = (from p in _db.Products
                            select p).ToList();
            return products;
        }

        //public List<Products> GetProductsByType(Guid typid)
        //{
        //    var products = _db.Products.Where(p => p.ProductTypeID == typid);
        //    return products.ToList();
        //}
    }
}
