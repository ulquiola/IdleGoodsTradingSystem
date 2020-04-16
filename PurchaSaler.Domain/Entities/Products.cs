using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PurchaSaler.Domain.Entities
{
    public class Products
    {
        //12
        [Key]
        public Guid ProductID { get; set; }
        public Guid OwnerID { get; set; }
        public string ProductName { get; set; }
        public Guid ProductTypeID { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string image { get; set; }
        public string photo1 { get; set; }
        public string photo2 { get; set; }
        public string photo3 { get; set; }


    }
}
