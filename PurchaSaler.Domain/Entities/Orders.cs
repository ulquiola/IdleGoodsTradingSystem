﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaSaler.Domain.Entities
{
    public class Orders
    {
        public Guid OrderID { get; set; }
        public Guid UserID { get; set; }
        public DateTime OrderTime { get; set; }
        public int Amount { get; set; }
        public string OrderState { get; set; }

    }
}
