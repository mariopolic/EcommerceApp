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
        public  IActionResult GetAllOrders()
        {
            return Ok();
        }
        [HttpGet("get/{orderId}")]
        public IActionResult GetSingleOrder(int orderId)
        {
            return Ok();
        }
        [HttpPost("add/{customerId}")]
        public async Task<IActionResult> AddOrder(int customerId)
           => Ok(await this.orderService.AddOrder(customerId));

        [HttpPut("update/{OrderId}")]
        public  IActionResult UpdateOrder(int OrderId, [FromBody] ProductRequestModel productRequest)
        {
            return Ok();
        }

        [HttpDelete("delete/{OrderId}")]
        public  IActionResult DeleteOrder(int OrderId)
        {
            return Ok(OrderId);
        }
    }
}
