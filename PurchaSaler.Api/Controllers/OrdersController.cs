using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurchaSaler.Api.ViewModel;
using PurchaSaler.Domain.Entities;
using PurchaSaler.Domain.IRepositories;

namespace PurchaSaler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : CorsController
    {
        private readonly IOrdersRepository _ordersRepository;

        public OrdersController(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }
        [Authorize]
        [HttpPost("GenerateOrders")]
        public IActionResult GenerateOrders([FromBody]Orders orders)
        {
            //all=12
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var obj = new Orders();
            //主键自增
            obj.UserID = Convert.ToInt32(claimsIdentity.FindFirst(ClaimTypes.Name)?.Value);
            obj.ProductID = orders.ProductID;
            obj.ProductName = orders.ProductName;
            obj.ProductImg = orders.ProductImg;
            obj.Number = orders.Number;
            obj.UnitPrice = orders.UnitPrice;
            obj.TotalPrice = orders.TotalPrice;
            obj.OrderCreateTime = DateTime.Now.ToString("F");
            obj.ReceivePeople = orders.ReceivePeople;
            obj.Phone = orders.Phone;
            obj.Address = orders.Address;
            _ordersRepository.AddOrders(obj);
            return Ok("支付成功");            
        }

        [Authorize]
        [HttpGet("GetOrders")]
        public IActionResult GerOrders()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userid = Convert.ToInt32(claimsIdentity.FindFirst(ClaimTypes.Name)?.Value);
            var orders = _ordersRepository.GetSomeOneOrders(userid);
            return new JsonResult(orders);
        }

        [HttpPost("GetOrderDetail")]
        public IActionResult GetOrderDetail([FromBody]RequestId id)
        {
            var orderid = id.Id;
            var order = _ordersRepository.OrderDetail(orderid);
            return new JsonResult(order);
        }

        [Authorize]
        [HttpPost("DelOrder")]
        public IActionResult DelOrder([FromBody]RequestId id)
        {
            var orderid = id.Id;
            _ordersRepository.DelOrder(orderid);
            return Ok("删除成功");
        }
    }
}