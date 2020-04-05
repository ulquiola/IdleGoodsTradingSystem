using PurchaSaler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaSaler.Domain.IRepositories
{
    public interface IShoppingCartsRepository
    {
        IEnumerable<ShoppingCarts> GetSomeOneAllShoppingCarts(Guid userid);
        void AddShoppingCarts(ShoppingCarts shopcart);
        void RemoveShoppingCarts(ShoppingCarts shopcart);
        ShoppingCarts GetOneShoppingCart(Guid productid);
        void RemoveAllShoppingCarts(IEnumerable<ShoppingCarts> shopcart);
        int GetShoppingCartsCount(Guid userid, Guid productid);


    }
}
