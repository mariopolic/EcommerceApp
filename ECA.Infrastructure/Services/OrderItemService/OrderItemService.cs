using Azure.Core;
using ECA.Core.Models;
using ECA.Infrastructure.Factories;
using ECA.Infrastructure.Repositories;
using ECA.ViewModels.RequestModel;
using ECA.ViewModels.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.Services.OrderItemService
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository itemRepository;
        private readonly ICustomerRepository customerRepository;
        public OrderItemService(IOrderItemRepository ItemRepository, ICustomerRepository CustomerRepository)
        {
            itemRepository = ItemRepository;
            customerRepository = CustomerRepository;

        }
        public async Task<OrderItemResponseModel> AddOrderItem(int customerId, int orderId, OrderItemRequestModel orderItemRequest)
        {
            Customer customer = await this.customerRepository.GetByIdAsync(customerId);
            if (customer == null || customer.IsDeleted==true)
            {
                throw new Exception("Customer does not exist!");
            }
            var item = OrderItemFactory.Create(orderItemRequest, orderId);
            await this.itemRepository.AddAsync(item);
            var response = OrderItemFactory.Create(item);
            return response;
        }

        public async Task<SuccessResponseModel> DeleteOrderItem( int orderId)
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
                throw new Exception("User not found");
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
