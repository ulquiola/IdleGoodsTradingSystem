using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PurchaSaler.Domain.Entities
{
    public class ShoppingCarts
    {
        [Key]
        public int ShoppingCartID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int Number { get; set; }
        public double UnitPrice { get; set; }
        public double TotalAmount { get; set; }

    }
}
