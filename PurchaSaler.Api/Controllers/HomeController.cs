using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public IActionResult Index()
        {
            var list = _productsRepository.GetAllProducts();
            return new JsonResult(list);
        }
    }
}