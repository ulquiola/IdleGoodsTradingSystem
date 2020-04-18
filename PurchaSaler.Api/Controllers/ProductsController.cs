using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurchaSaler.Api.Services;
using PurchaSaler.Api.ViewModel;
using PurchaSaler.Domain.Entities;
using PurchaSaler.Domain.IRepositories;
using PurchaSaler.Infrastructure.ORM;

namespace PurchaSaler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CorsController
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IWebHostEnvironment _environment;

        public ProductsController(IProductsRepository productsRepository, IWebHostEnvironment environment)
        {
            _productsRepository = productsRepository;
            _environment = environment;
        }

        [HttpGet("ProductDetail")]
        public IActionResult GetProductDetail(int productid)
        {
            var product = _productsRepository.GetProductByID(productid);
            return new JsonResult(product);
        }

        [Authorize]
        [HttpPost("AddProduct")]
        //[FormBody]要加，不然报400错误
        public IActionResult AddProduct([FromBody]AddProductVM productVM)
        {
            //all=12 
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var product = new Products();
            //主键自增
            product.OwnerID = Convert.ToInt32(claimsIdentity.FindFirst(ClaimTypes.Name)?.Value);
            product.ProductName = productVM.ProductName;
            product.ProductTypeID = Convert.ToInt32(productVM.ProductTypeID);
            product.Description = productVM.Description;
            product.Price = Convert.ToDouble(productVM.Price);
            product.Status = "";
            product.Stock = Convert.ToInt32(productVM.Stock);
            product.image = productVM.image;
            product.photo1 = productVM.photo1;
            product.photo2 = productVM.photo2;
            product.photo3 = productVM.photo3;            
            _productsRepository.AddProduct(product);
            return Ok();
        }

        [Authorize]
        [HttpPost("UpdateProduct")]
        public IActionResult UpdateProduct([FromBody]UpdateProductVM productVM)
        {
            var product = new Products();
            product.ProductID = Convert.ToInt32(productVM.ProductID);
            product.OwnerID = Convert.ToInt32(productVM.OwnerID);
            product.ProductTypeID = Convert.ToInt32(productVM.ProductTypeID);
            product.ProductName = productVM.ProductName;
            product.Description = productVM.Description;
            product.Price = Convert.ToDouble(productVM.Price);
            product.Status = "";
            product.Stock = Convert.ToInt32(productVM.Stock);
            product.image = productVM.image;
            product.photo1 = productVM.photo1;
            product.photo2 = productVM.photo2;
            product.photo3 = productVM.photo3;
            _productsRepository.UpdateProduct(product);
            return Ok("修改成功");
        }

        [Authorize]
        [HttpPost("DelProduct")]
        public IActionResult DelProduct([FromBody]RequestId id)
        {
            var pid = id.Id;
            _productsRepository.DelProducts(pid);
            return Ok("删除成功");
        }

        [Authorize]
        [HttpPost("UploadPhotos")]
        public IActionResult UploadPhotos(List<IFormFile> files)
        {
            var uploadObj = new UploadPhotos(_environment);
            List<string> filesPath= uploadObj.Upload(files);
            return Ok(filesPath);
        }

        [Authorize]
        [HttpGet("GetMyProducts")]
        public IActionResult GetMyProducts()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            int ownerid = Convert.ToInt32(claimsIdentity.FindFirst(ClaimTypes.Name)?.Value);
            var products = _productsRepository.GetMyProducts(ownerid);
            return new JsonResult(products);
        }        

        //使用对象传递参数，解决guid传递问题
        [HttpPost("GetProduct")]
        public IActionResult GetProduct([FromBody]RequestId id)
        {
            var pid = id.Id;
            var product = _productsRepository.GetProductByID(pid);
            return new JsonResult(product);
        }
    }
}