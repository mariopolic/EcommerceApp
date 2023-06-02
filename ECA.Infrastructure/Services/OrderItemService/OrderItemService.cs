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
            if (customer == null)
            {
                throw new Exception("Customer does not exist!");
            }
            var item = OrderItemFactory.Create(orderItemRequest);
            await this.itemRepository.AddAsync(item);
            var response = OrderItemFactory.Create(item);
            return response;
        }

        public Task<SuccessResponseModel> DeleteOrderItem(int customerId, int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderItemResponseModel>> GetAllOrderItems()
        {
            throw new NotImplementedException();
        }

        public Task<OrderItemResponseModel> GetSingleOrderItem(int OrderId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItemResponseModel> UpdateOrderItem(int OrderId, OrderRequestModel orderRequest)
        {
            throw new NotImplementedException();
        }
    }
}
