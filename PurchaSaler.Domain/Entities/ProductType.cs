using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PurchaSaler.Domain.Entities
{
    public class ProductType
    {
        [Key]
        public int TypeID { get; set; }
        public string TypeName { get; set; }

    }
}
