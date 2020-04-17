using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurchaSaler.Domain.Entities;
using PurchaSaler.Domain.IRepositories;

namespace PurchaSaler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : CorsController
    {
        private readonly IOrdersRepository _ordersRepository;
        private IOrderItemsRepository _orderItemsRepository;

        public OrdersController(IOrdersRepository ordersRepository, IOrderItemsRepository orderItemsRepository)
        {
            _ordersRepository = ordersRepository;
            _orderItemsRepository = orderItemsRepository;
        }
        [HttpPost("GenerateOrders")]
        public IActionResult GenerateOrders(Orders orders)
        {
            //orders.OrderID = new Guid();
            _ordersRepository.AddOrders(orders);
            ////orderItems.OrderID = orders.OrderID;
            ////_orderItemsRepository.AddOrderItems(orderItems);
            return Ok();            
        }
    }
}