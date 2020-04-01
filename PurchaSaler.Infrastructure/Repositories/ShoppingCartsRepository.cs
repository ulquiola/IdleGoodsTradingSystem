using PurchaSaler.Domain.Entities;
using PurchaSaler.Domain.IRepositories;
using PurchaSaler.Infrastructure.ORM;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaSaler.Infrastructure.Repositories
{
    public class ShoppingCartsRepository: IShoppingCartsRepository
    {
        private readonly PurchaSalerDbContext _db;

        public ShoppingCartsRepository(PurchaSalerDbContext db)
        {
            _db = db;
        }

        public void AddShoppingCarts(ShoppingCarts shopcart)
        {
            _db.ShoppingCarts.Add(shopcart);
            _db.SaveChanges();
        }

        public IEnumerable<ShoppingCarts> GetAllShoppingCarts(Guid userid)
        {
            throw new NotImplementedException();
        }

        public ShoppingCarts GetOneShoppingCart(Guid productid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShoppingCarts> GetShoppingCarts(Guid userid)
        {
            throw new NotImplementedException();
        }

        public int GetShoppingCartsCount(Guid userid, Guid productid)
        {
            throw new NotImplementedException();
        }

        public void RemoveAllShoppingCarts(IEnumerable<ShoppingCarts> shopcart)
        {
            throw new NotImplementedException();
        }

        public void RemoveShoppingCarts(ShoppingCarts shopcart)
        {
            throw new NotImplementedException();
        }
    }
}
