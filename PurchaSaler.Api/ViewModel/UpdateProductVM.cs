using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurchaSaler.Api.ViewModel
{
    public class UpdateProductVM
    {
        public string ProductID { get; set; }
        public string OwnerID { get; set; }
        public string ProductName { get; set; }
        public string ProductTypeID { get; set; }
        public string Price { get; set; }
        public string Stock { get; set; }
        public string Description { get; set; }
        public string image { get; set; }
        public string photo1 { get; set; }
        public string photo2 { get; set; }
        public string photo3 { get; set; }
    }
}
