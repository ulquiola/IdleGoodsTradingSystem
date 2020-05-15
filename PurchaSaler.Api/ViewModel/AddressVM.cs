using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaSaler.Api.ViewModel
{
    public class AddressVM
    {
        public string name { get; set; }
        public int phone { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string AddressDetail { get; set; }
    }
}
