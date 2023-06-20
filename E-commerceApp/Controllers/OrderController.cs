using ECA.Core.Models;
using ECA.Infrastructure.Services.OrderItemService;
using ECA.Infrastructure.Services.OrderService;
using ECA.ViewModels.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerceApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IOrderItemService orderItemService;
        public OrderController(IOrderService OrderService, IOrderItemService OrderItemService)
        {
          orderService = OrderService;
          orderItemService = OrderItemService;
        }
        [HttpGet("GetAll")]
        public  async Task<IActionResult> GetAllOrders()
        {
            return Ok(await this.orderService.GetAllOrders());
        }
        [HttpGet("get/{orderId}")]
        public async Task<IActionResult> GetSingleOrder(int orderId)
        {
            var singleOrder = await this.orderService.GetSingleOrder(orderId);
            if(singleOrder == null || singleOrder.Customer == null)
            {
                return NotFound("sorry this order does not exist!");
            }
            return Ok(singleOrder);
        }
        [HttpPost("add/{customerId}")]
        public async Task<IActionResult> AddOrder(int customerId)
           => Ok(await this.orderService.AddOrder(customerId));

        [HttpGet("get/customer/{customerId}")]
        public async Task<IActionResult> GetOrdersByCustomer(int customerId)
        {
            return Ok(await this.orderService.GetAllOrdersFromCustomer(customerId));
        }

        [HttpPut("update/{OrderId}")]
        public  async Task<IActionResult> UpdateOrder(int OrderId, [FromBody] OrderRequestModel orderRequest)
        {
            return Ok(await this.orderService.UpdateOrder(OrderId,orderRequest));
        }

        [HttpDelete("delete/{OrderId}")]
        public  async Task<IActionResult> DeleteOrder(int OrderId)
        {
            var result = await this.orderService.DeleteOrder(OrderId);
            if (result == null)
                return NotFound("Sorry but this product does not exist");
            return Ok(result);
        }
    }
}
