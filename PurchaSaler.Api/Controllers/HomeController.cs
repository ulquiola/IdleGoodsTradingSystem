using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PurchaSaler.Api.ViewModel;
using PurchaSaler.Domain.IRepositories;

namespace PurchaSaler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : CorsController
    {
        private readonly IProductsRepository _productsRepository;

        public HomeController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }
        [HttpGet("GetProductList")]
        public IActionResult GetProductList()
        {
            var list = _productsRepository.GetAllProducts();
            return new JsonResult(list);
        }
        [HttpPost("SearchByString")]
        public IActionResult SearchByString([FromBody]Search search)
        {
            string searchStr = search.searchStr; 
            if (searchStr != null)
            {
                var data = _productsRepository.SearchProductByStr(searchStr);
                return new JsonResult(data);
            }
            return Ok("null");
        }
        [HttpPost("SearchByType")]
        public IActionResult SearchByType([FromBody]Search search)
        {
            int typeid = search.typeid;
            var data = _productsRepository.SearchProductByTypeID(typeid);
            return new JsonResult(data);
        }
        public class Search
        {
            public int typeid { get; set; }
            public string searchStr { get; set; }
        }
    }
}