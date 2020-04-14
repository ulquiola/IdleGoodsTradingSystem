using PurchaSaler.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaSaler.Domain.IRepositories
{
    public interface IOrderItemsRepository
    {
        void AddOrderItems(OrderItems orderItems);
    }
}
