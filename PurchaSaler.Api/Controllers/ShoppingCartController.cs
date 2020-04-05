using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PurchaSaler.Domain.Entities;
using PurchaSaler.Domain.IRepositories;

namespace PurchaSaler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : CorsController
    {
        private readonly IShoppingCartsRepository _shoppingCartsRepository;

        public ShoppingCartController(IShoppingCartsRepository shoppingCartsRepository)
        {
            _shoppingCartsRepository = shoppingCartsRepository;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetCarts()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            Guid userid = new Guid(claimsIdentity.FindFirst(ClaimTypes.Name)?.Value);
            var shoppingcart = _shoppingCartsRepository.GetSomeOneAllShoppingCarts(userid);
            return new JsonResult(shoppingcart);
        }
        [HttpPost]
        public IActionResult AddShoppingCarts(ShoppingCarts carts)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            Guid userid =new Guid (claimsIdentity.FindFirst(ClaimTypes.Name)?.Value);
            Guid productid = carts.ProductID;
            int result = _shoppingCartsRepository.GetShoppingCartsCount(userid,productid);
            if (result > 0)
            {
                return Content("<script>alert('该商品已存在购物车');history.go(-1)</script>");
            }
            else
            {
                carts.TotalAmount = carts.Number * carts.UnitPrice;
                _shoppingCartsRepository.AddShoppingCarts(carts);
                return Content("<script>alert('添加成功');history.go(-1)</script>");
            }
        }
        [HttpPost]
        public ActionResult Remove(Guid productid)
        {
            var delobj = _shoppingCartsRepository.GetOneShoppingCart(productid);
            if (delobj != null)
            {
                _shoppingCartsRepository.RemoveShoppingCarts(delobj);
            }
            return Ok();
        }
        [HttpPost]
        public ActionResult RemoveAll(Guid userid)
        {
            var removeall = _shoppingCartsRepository.GetSomeOneAllShoppingCarts(userid);
            if (removeall != null)
            {
                _shoppingCartsRepository.RemoveAllShoppingCarts(removeall);
            }
            return Ok();
        }
    }
}