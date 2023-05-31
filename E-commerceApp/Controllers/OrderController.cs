using ECA.ViewModels.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerceApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
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
        public IActionResult AddOrder(int customerId)
           => Ok();

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
