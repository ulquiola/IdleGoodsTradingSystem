using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PurchaSaler.Domain.Entities
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string AddressDetail { get; set; }
        public bool IsDefault { get; set; }

    }
}
