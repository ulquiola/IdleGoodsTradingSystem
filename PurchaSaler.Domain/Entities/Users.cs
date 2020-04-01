using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaSaler.Domain.Entities
{
    public class Users
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
