using PurchaSaler.Domain.Entities;
using PurchaSaler.Domain.IRepositories;
using PurchaSaler.Infrastructure.ORM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PurchaSaler.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly PurchaSalerDbContext _db;

        public OrdersRepository(PurchaSalerDbContext db)
        {
            _db = db;
        }
        public void AddOrders(Orders orders)
        {
            _db.Orders.Add(orders);
            _db.SaveChanges();
        }

        public void DelOrder(int orderid)
        {
            var order = _db.Orders.Find(orderid);
            _db.Orders.Remove(order);
            _db.SaveChanges();
        }

        public List<Orders> GetSomeOneOrders(int userid)
        {
            var data = (from o in _db.Orders
                        where o.UserID == userid
                        select o).ToList();
            return data;

        }

        public Orders OrderDetail(int orderid)
        {
            var data = _db.Orders.Find(orderid);
            return data;
        }
    }
}
