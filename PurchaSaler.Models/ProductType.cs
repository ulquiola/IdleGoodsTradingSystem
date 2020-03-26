﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PurchaSaler.Models
{
    public class ProductType
    {
        [Key]
        public Guid TypeID { get; set; }
        public string TypeName { get; set; }

    }
}
