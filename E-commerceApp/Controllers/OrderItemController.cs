using ECA.Infrastructure.Services.OrderItemService;
using ECA.ViewModels.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerceApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService itemService; 
        public OrderItemController(IOrderItemService ItemService)
        {
            itemService = ItemService;
        }
        [HttpPost("add/customer/{customerId}/order/{orderId}")]
        public async Task<IActionResult> AddItemToOrder(int customerId, int orderId, [FromBody] OrderItemRequestModel orderItemRequest)
         => Ok(await this.itemService.AddOrderItem(customerId, orderId, orderItemRequest));

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllOrderItems()
         => Ok(await this.itemService.GetAllOrderItems());

        [HttpPut("update/{OrderItemId}")]
        public async Task<IActionResult> UpdateOrder(int OrderItemId, [FromBody] OrderItemRequestModel orderRequest)
        {
            return Ok(await this.itemService.UpdateOrderItem(OrderItemId, orderRequest));
        }

        [HttpDelete("delete/{OrderItemId}")]
        public async Task<IActionResult> DeleteOrderItem(int OrderItemId)
        {
            return Ok(await this.itemService.DeleteOrderItem(OrderItemId));
        }
    }
}
