using PurchaSaler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaSaler.Domain.IRepositories
{
    public interface IShoppingCartsRepository
    {
        IEnumerable<ShoppingCarts> GetSomeOneAllShoppingCarts(int userid);
        void AddShoppingCarts(ShoppingCarts shopcart);
        void RemoveShoppingCarts(ShoppingCarts shopcart);
        ShoppingCarts GetOneShoppingCart(int cartid);
        void RemoveAllShoppingCarts(IEnumerable<ShoppingCarts> shopcart);
        int GetShoppingCartsCount(int userid, int productid);


    }
}
