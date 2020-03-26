using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaSaler.Models
{
    public class Users
    {
        public Guid id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
