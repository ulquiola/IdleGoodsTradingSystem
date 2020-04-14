using PurchaSaler.Domain.Entities;
using PurchaSaler.Domain.IRepositories;
using PurchaSaler.Infrastructure.ORM;
using System;
using System.Collections.Generic;
using System.Text;

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

    }
}
