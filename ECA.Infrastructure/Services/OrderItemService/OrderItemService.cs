using ECA.Core.Exceptions;
using ECA.Core.Models;
using ECA.Infrastructure.Factories;
using ECA.Infrastructure.Repositories;
using ECA.Infrastructure.Services.OrderService;
using ECA.ViewModels.RequestModel;
using ECA.ViewModels.ResponseModel;

namespace ECA.Infrastructure.Services.OrderItemService
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository itemRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IOrderService orderService;
        public OrderItemService(IOrderItemRepository ItemRepository, ICustomerRepository CustomerRepository, IOrderService OrderService)
        {
            itemRepository = ItemRepository;
            customerRepository = CustomerRepository;
            orderService = OrderService;

        }
        public async Task<OrderItemResponseModel> AddOrderItem(int customerId, int orderId, OrderItemRequestModel orderItemRequest)
        {
            Customer customer = await this.customerRepository.GetByIdAsync(customerId);
            if (customer == null || customer.IsDeleted == true)
            {
                throw new EntityNotFoundException("Customer does not exist!");
            }
            var item = OrderItemFactory.Create(orderItemRequest, orderId);
            if(item.Quantity > 0)
            {
                await this.itemRepository.AddAsync(item);
                await this.orderService.UpdateOrderPrice(orderId);
            }
            var response = OrderItemFactory.Create(item);
            return response;
        }

        public async Task<SuccessResponseModel> DeleteOrderItem(int orderId)
        {
            OrderItem deleteOrder = await this.itemRepository.GetByIdAsync(orderId);
            if (deleteOrder == null)
                throw new Exception("Order does not exist!");

            deleteOrder.IsDeleted = true;
            await this.itemRepository.UpdateAsync(deleteOrder);
            return new SuccessResponseModel() { Success = deleteOrder.IsDeleted };
        }

        public async Task<IEnumerable<OrderItemResponseModel>> GetAllOrderItems()
        {

            var allOrderItems = (await this.itemRepository.GetAsync(x => x.IsDeleted == false)).ToList();
            var responseModels = allOrderItems.Select(x => OrderItemFactory.Create(x));
            return responseModels;
        }

        public async Task<OrderItemResponseModel> GetSingleOrderItem(int OrderItemId)
        {
            var OrderItem = await this.itemRepository.GetByIdAsync(OrderItemId);
            if (OrderItem == null)
            {
                throw new EntityNotFoundException("Order Item not found");
            }
            OrderItemResponseModel response = OrderItemFactory.Create(OrderItem);
            return response;
        }

        public async Task<OrderItemResponseModel> UpdateOrderItem(int OrderId, OrderItemRequestModel orderRequest)
        {
            var updateOrderItem = await this.itemRepository.GetByIdAsync(OrderId);
            updateOrderItem.Price = orderRequest.Price;
            updateOrderItem.Quantity = orderRequest.Quantity;
            updateOrderItem.ProductId = orderRequest.ProductId;
            await this.itemRepository.UpdateAsync(updateOrderItem);
            var response = OrderItemFactory.Create(updateOrderItem);
            return response;
        }
    }
}
