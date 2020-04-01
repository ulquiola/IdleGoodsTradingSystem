using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaSaler.Domain.Entities
{
    public class ShoppingCarts
    {
        public Guid ShoppingCartID { get; set; }
        public Guid UserID { get; set; }
        public Guid ProductID { get; set; }
        public int Number { get; set; }
        public double UnitPrice { get; set; }
        public double TotalAmount { get; set; }

    }
}
