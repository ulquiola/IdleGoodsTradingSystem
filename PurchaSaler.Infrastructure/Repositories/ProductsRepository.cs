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

        public void DelProducts(int productid)
        {
            var product = _db.Products.Single(p => p.ProductID == productid);
            _db.Products.Remove(product);
            _db.SaveChanges();
        }

        public List<Products> GetAllProducts()
        {
            var products = (from p in _db.Products
                            select p).ToList();
            return products;
        }

        public List<Products> GetMyProducts(int ownerid)
        {
            var products = (from p in _db.Products
                            where p.OwnerID == ownerid
                            select p).ToList();
            return products;
        }

        public Products GetProductByID(int productid)
        {
            var product = (from p in _db.Products
                           where p.ProductID == productid
                           select p).FirstOrDefault();
            return product;
        }

        public List<Products> SearchProductByStr(string searchStr)
        {
            var data = (from d in _db.Products
                        where d.ProductName.Contains(searchStr) || d.Description.Contains(searchStr)
                        select d).ToList();
            return data;
        }

        public List<Products> SearchProductByTypeID(int typeid)
        {
            var data = (from d in _db.Products
                        where d.ProductTypeID ==typeid
                        select d).ToList();
            return data;
        }

        public void UpdateProduct(Products product)
        {
            _db.Entry(product).State = EntityState.Modified;
            _db.SaveChanges();
        }


        //public List<Products> GetProductsByType(int typid)
        //{
        //    var products = _db.Products.Where(p => p.ProductTypeID == typid);
        //    return products.ToList();
        //}
    }
}
