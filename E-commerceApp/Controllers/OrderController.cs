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
        public OrderController(IOrderService OrderService)
        {
          orderService = OrderService;
        }
        [HttpGet("GetAll")]
        public  async Task<IActionResult> GetAllOrders()
        {
            return Ok(await this.orderService.GetAllOrders());
        }
        [HttpGet("get/{orderId}")]
        public async Task<IActionResult> GetSingleOrder(int orderId)
        {
            return Ok(await this.orderService.GetSingleOrder(orderId));
        }
        [HttpPost("add/{customerId}")]
        public async Task<IActionResult> AddOrder(int customerId)
           => Ok(await this.orderService.AddOrder(customerId));

        [HttpPut("update/{OrderId}")]
        public  async Task<IActionResult> UpdateOrder(int OrderId, [FromBody] OrderRequestModel orderRequest)
        {
            return Ok(await this.orderService.UpdateOrder(OrderId));
        }

        [HttpDelete("delete/{OrderId}")]
        public  IActionResult DeleteOrder(int OrderId)
        {
            return Ok(OrderId);
        }
    }
}
