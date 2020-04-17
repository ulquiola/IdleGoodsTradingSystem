using PurchaSaler.Domain.Entities;
using PurchaSaler.Domain.IRepositories;
using PurchaSaler.Infrastructure.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<ShoppingCarts> GetSomeOneAllShoppingCarts(int userid)
        {
            var carts = (from c in _db.ShoppingCarts
                         where c.UserID == userid
                         select c);
            return carts;
        }

        public ShoppingCarts GetOneShoppingCart(int productid)
        {
            var data = (from d in _db.ShoppingCarts
                        where d.ProductID == productid
                        select d).FirstOrDefault();
            return data;
        }

        public IEnumerable<ShoppingCarts> GetShoppingCarts(int userid)
        {
            var carts = (from c in _db.ShoppingCarts
                         where c.UserID == userid
                         select c);
            return carts;
        }

        public int GetShoppingCartsCount(int userid, int productid)
        {
            int data = (from p in _db.ShoppingCarts
                        where p.UserID == userid && p.ProductID == productid
                        select p).Count();
            return data;
        }

        public void RemoveAllShoppingCarts(IEnumerable<ShoppingCarts> shopcart)
        {
            throw new NotImplementedException();
        }

        public void RemoveShoppingCarts(ShoppingCarts shopcart)
        {
            _db.ShoppingCarts.RemoveRange(shopcart);
            _db.SaveChanges();
        }

    }
}
