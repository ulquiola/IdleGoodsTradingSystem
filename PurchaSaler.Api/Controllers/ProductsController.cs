using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurchaSaler.Infrastructure.ORM;

namespace PurchaSaler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CorsController
    {
        private readonly PurchaSalerDbContext _db;
        public ProductsController(PurchaSalerDbContext db)
        {
            _db = db;
        }

        [HttpGet("ProductDetail")]
        public IActionResult GetProductDetail(Guid id)
        {
            var product = (from p in _db.Products
                           where p.ProductID == id
                           select p).FirstOrDefault();
            return new JsonResult(product);
        }

        [HttpPost("AddShoppingCart")]
        public IActionResult AddShoppingCart()
        {
            return Ok();
        }
    }
}