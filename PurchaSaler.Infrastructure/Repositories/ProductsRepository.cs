using PurchaSaler.Domain.Entities;
using PurchaSaler.Domain.IRepositories;
using PurchaSaler.Infrastructure.ORM;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System;
using Microsoft.EntityFrameworkCore;

namespace PurchaSaler.Infrastructure.Repositories
{
    public class ProductsRepository:IProductsRepository
    {
        private readonly PurchaSalerDbContext _db;

        public ProductsRepository(PurchaSalerDbContext db)
        {
            _db = db;
        }

        public void AddProduct(Products product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public void DelProducts(Guid productid)
        {
            var product = (from p in _db.Products
                           where p.ProductID == productid
                           select p).FirstOrDefault();
            _db.Products.Remove(product);
        }

        public List<Products> GetAllProducts()
        {
            var products = (from p in _db.Products
                            select p).ToList();
            return products;
        }

        public List<Products> GetMyProducts(Guid ownerid)
        {
            var products = (from p in _db.Products
                            where p.OwnerID == ownerid
                            select p).ToList();
            return products;
        }

        public Products GetProductByID(Guid productid)
        {
            var product = (from p in _db.Products
                           where p.ProductID == productid
                           select p).FirstOrDefault();
            return product;
        }

        public void UpdateProduct(Products product)
        {
            _db.Entry(product).State = EntityState.Modified;
            _db.SaveChanges();
        }


        //public List<Products> GetProductsByType(Guid typid)
        //{
        //    var products = _db.Products.Where(p => p.ProductTypeID == typid);
        //    return products.ToList();
        //}
    }
}
