using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PurchaSaler.Models
{
    public class Products
    {
        [Key]
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public Guid ProductTypeID { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Photos { get; set; }

    }
}
