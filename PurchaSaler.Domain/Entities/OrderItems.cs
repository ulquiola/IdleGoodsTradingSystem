using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PurchaSaler.Domain.Entities
{
    public class OrderItems
    {
        [Key]
        public Guid OrderItemsID { get; set; }
        public Guid OrderID { get; set; }
        public Guid ProductID { get; set; }
        public double UnitPrice { get; set; }
        public int Number { get; set; }
        public double TotalAmount { get; set; }

    }
}
