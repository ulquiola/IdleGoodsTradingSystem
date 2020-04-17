using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PurchaSaler.Domain.Entities
{
    public class OrderItems
    {
        [Key]
        public int OrderItemsID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public double UnitPrice { get; set; }
        public int Number { get; set; }
        public double TotalAmount { get; set; }

    }
}
