using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurchaSaler.Models;

namespace PurchaSaler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly PurchaSalerDbContext _db;
        public TestController(PurchaSalerDbContext db)
        {
            _db = db;
        }


        //添加测试用例
        //user.UserName = "ulquiola";
        //user.Email = "ulquiola@163.com";
        //user.Password = "123456";
        //_db.Users.Add(user);
        //_db.SaveChanges();
        //return Ok();

        //添加类型
        [HttpPost("AddType")]
        public IActionResult AddType()
        {
            var type = new ProductType();
            type.TypeName = "美妆饰品";
            _db.ProductTypes.Add(type);
            _db.SaveChanges();
            return Ok();
        }
        //添加商品
        [HttpPost("AddProduct")]
        public IActionResult AddProduct()
        {
            var product1 = new Products()
            {
                ProductName = "test6",
                Price = 60,
                Description="",
                Photos= "img/n4.jpg",
                ProductTypeID = new Guid("288804E4-3AE8-4F28-B790-08D7D16BE776"),
                Stock=1,
                Status="审核通过"
            };
            var product2 = new Products()
            {
                ProductName = "test7",
                Price = 70,
                Description = "",
                Photos = "img/n4.jpg",
                ProductTypeID = new Guid("E020F801-68F0-4903-7164-08D7D16CF8EA"),
                Stock = 1,
                Status = "审核通过"
            };
            var product3 = new Products()
            {
                ProductName = "test8",
                Price = 80,
                Description = "",
                Photos = "img/n4.jpg",
                ProductTypeID = new Guid("CA62C608-21DD-435A-14B7-08D7D16D1D31"),
                Stock = 1,
                Status = "审核通过"
            };
            var product4 = new Products()
            {
                ProductName = "test9",
                Price = 90,
                Description = "",
                Photos = "img/n4.jpg",
                ProductTypeID = new Guid("4FF898D3-1A4C-4C48-1445-08D7D16D4B84"),
                Stock = 1,
                Status = "审核通过"
            };
            var product5 = new Products()
            {
                ProductName = "test10",
                Price = 100,
                Description = "",
                Photos = "img/n4.jpg",
                ProductTypeID = new Guid("4F8CC6AA-AB19-466C-500B-08D7D16D7872"),
                Stock = 1,
                Status = "审核通过"
            };
            _db.Products.AddRange(product1,product2,product3,product4,product5);
            _db.SaveChanges();
            return Ok();
        }
    }
}