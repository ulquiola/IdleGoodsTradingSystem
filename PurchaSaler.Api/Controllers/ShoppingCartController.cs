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
        [HttpGet("GetCarts")]
        public IActionResult GetCarts()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            int userid = Convert.ToInt32(claimsIdentity.FindFirst(ClaimTypes.Name)?.Value);
            var shoppingcart = _shoppingCartsRepository.GetSomeOneAllShoppingCarts(userid);
            return new JsonResult(shoppingcart);
        }

        [Authorize]
        [HttpPost("AddShoppingCarts")]
        public IActionResult AddShoppingCarts([FromBody]ShoppingCarts shoppingCart)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            int userid = Convert.ToInt32(claimsIdentity.FindFirst(ClaimTypes.Name)?.Value);
            int productid = shoppingCart.ProductID;
            var cart = new ShoppingCarts()
            {
                //ShoppingCartID 自增
                UserID = userid,
                ProductID = productid,
                Number = shoppingCart.Number,
                UnitPrice = shoppingCart.UnitPrice,
                TotalPrice = shoppingCart.TotalPrice,
            };
            int result = _shoppingCartsRepository.GetShoppingCartsCount(userid,productid);
            if (result > 0)
            {
                return StatusCode(403,"商品已存在与购物车");
            }
            else
            {
                _shoppingCartsRepository.AddShoppingCarts(cart);
                return Ok("添加成功");
            }
        }
        [HttpPost("Remove")]
        public ActionResult Remove(int productid)
        {
            var delobj = _shoppingCartsRepository.GetOneShoppingCart(productid);
            if (delobj != null)
            {
                _shoppingCartsRepository.RemoveShoppingCarts(delobj);
            }
            return Ok();
        }
        [HttpPost("RemoveAll")]
        public ActionResult RemoveAll(int userid)
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