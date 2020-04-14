using PurchaSaler.Domain.Entities;
using PurchaSaler.Domain.IRepositories;
using PurchaSaler.Infrastructure.ORM;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaSaler.Infrastructure.Repositories
{
    public class OrderItemsRepository : IOrderItemsRepository
    {
        private readonly PurchaSalerDbContext _db;

        public OrderItemsRepository(PurchaSalerDbContext db)
        {
            _db = db;
        }
        public void AddOrderItems(OrderItems orderItems)
        {
            _db.OrderItems.Add(orderItems);
            _db.SaveChanges();
        }
    }
}
