using PurchaSaler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaSaler.Domain.IRepositories
{
    public interface IProductsRepository
    {
        List<Products> GetAllProducts();
        List<Products> GetMyProducts(int ownerid);
        Products GetProductByID(int productid);
        void AddProduct(Products product);
        void DelProducts(int productid);
        void UpdateProduct(Products product);
        
    }
}
