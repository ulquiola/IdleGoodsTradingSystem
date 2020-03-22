using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaSaler.Models
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

    }
}
