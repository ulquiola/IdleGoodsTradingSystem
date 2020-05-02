using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PurchaSaler.Domain.Entities
{
    public class Orders
    {
        [Key]
        //public int OrderID { get; set; }
        //public int UserID { get; set; }
        //public int ProductID { get; set; }

        //public DateTime OrderTime { get; set; }
        //public int Amount { get; set; }
        //public string OrderState { get; set; }
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductImg { get; set; }
        public int Number { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public string ReceivePeople { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string OrderCreateTime { get; set; }
       

    }
}
