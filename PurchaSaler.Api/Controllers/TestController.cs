using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PurchaSaler.Domain.Entities;
using PurchaSaler.Domain.IRepositories;
using PurchaSaler.Infrastructure.ORM;

namespace PurchaSaler.Api.Controllers
{
    [EnableCors("any")]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly PurchaSalerDbContext _db;
        private readonly IProductsRepository _ps;

        public TestController(PurchaSalerDbContext db,IProductsRepository ps)
        {
            _db = db;
            _ps = ps;
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
            var type1 = new ProductType
            {
                TypeName = "智能数码"
            };
            var type2 = new ProductType
            {
                TypeName = "衣装服饰"
            };
            var type3 = new ProductType
            {
                TypeName = "书籍资料"
            };
            var type4 = new ProductType
            {
                TypeName = "电器设备"
            };
            var type5 = new ProductType
            {
                TypeName = "美妆饰品"
            };
            _db.ProductTypes.AddRange(type1,type2,type3,type4,type5);
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
                image= "img/n4.jpg",
                ProductTypeID = 1,
                Stock=1,
                Status="审核通过"
            };
            var product2 = new Products()
            {
                ProductName = "test7",
                Price = 70,
                Description = "",
                image = "img/n4.jpg",
                ProductTypeID = 1,
                Stock = 1,
                Status = "审核通过"
            };
            var product3 = new Products()
            {
                ProductName = "test8",
                Price = 80,
                Description = "",
                image = "img/n4.jpg",
                ProductTypeID = 1,
                Stock = 1,
                Status = "审核通过"
            };
            var product4 = new Products()
            {
                ProductName = "test9",
                Price = 90,
                Description = "",
                image = "img/n4.jpg",
                ProductTypeID = 1,
                Stock = 1,
                Status = "审核通过"
            };
            var product5 = new Products()
            {
                ProductName = "test10",
                Price = 100,
                Description = "",
                image = "img/n4.jpg",
                ProductTypeID = 1,
                Stock = 1,
                Status = "审核通过"
            };
            _db.Products.AddRange(product1,product2,product3,product4,product5);
            _db.SaveChanges();
            return Ok();
        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            var plist = _ps.GetAllProducts();
            return new JsonResult(plist);
        }
    }
}