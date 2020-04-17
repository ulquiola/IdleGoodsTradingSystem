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
        public IActionResult GetProductDetail(Guid productid)
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
            var product = new Products()
            {
                ProductID = new Guid(),
                OwnerID = new Guid(claimsIdentity.FindFirst(ClaimTypes.Name)?.Value),
                ProductName = productVM.ProductName,
                ProductTypeID = productVM.ProductTypeID,
                Description = productVM.Description,
                Price = Convert.ToDouble(productVM.Price),
                Status = "",
                Stock = Convert.ToInt32(productVM.Stock),
                image = productVM.image,
                photo1 = productVM.photo1,
                photo2 = productVM.photo2,
                photo3 = productVM.photo3,                
            };
            _productsRepository.AddProduct(product);
            return Ok();
        }

        [HttpPost("UpdateProduct")]
        public IActionResult UpdateProduct(Products product)
        {
            _productsRepository.UpdateProduct(product);
            return Ok();
        }
        [HttpPost("DelProduct")]
        public IActionResult DelProduct(Guid productid)
        {
            _productsRepository.DelProducts(productid);
            return Ok();
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
            Guid ownerid = new Guid(claimsIdentity.FindFirst(ClaimTypes.Name)?.Value);
            var products = _productsRepository.GetMyProducts(ownerid);
            return new JsonResult(products);
        }
    }
}