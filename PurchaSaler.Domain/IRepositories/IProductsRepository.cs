using PurchaSaler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaSaler.Domain.IRepositories
{
    public interface IProductsRepository
    {
        List<Products> GetAllProducts();
        Products GetProductByID(Guid productid);
        void AddProduct(Products product);
        void DelProducts(Guid productid);
        void UpdateProduct(Products product);
        
    }
}
