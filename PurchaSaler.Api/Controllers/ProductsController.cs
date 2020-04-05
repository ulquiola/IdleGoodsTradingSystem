using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        [HttpGet("ProductDetail")]
        public IActionResult GetProductDetail(Guid productid)
        {
            var product = _productsRepository.GetProductByID(productid);
            return new JsonResult(product);
        }

        [HttpPost]
        public IActionResult AddProduct(Products products)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            products.OwnerID = new Guid(claimsIdentity.FindFirst(ClaimTypes.Name)?.Value);

            _productsRepository.AddProduct(products);
            return Ok();
        }
    }
}