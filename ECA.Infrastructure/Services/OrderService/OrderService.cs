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

namespace ECA.Infrastructure.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly ICustomerRepository customerRepository;
        public OrderService(IOrderRepository OrderRepository, ICustomerRepository CustomerRepository)
        {
         orderRepository = OrderRepository;
         customerRepository = CustomerRepository;
        }
        public async Task<OrderResponseModel> AddOrder(int customerId)
        {
           Customer customer =  await this.customerRepository.GetByIdAsync(customerId);
           if(customer == null)
            {
                throw new Exception("Customer does not exist!");
            }
          Order newOrder =  OrderFactory.Create(customerId);
          await this.orderRepository.AddAsync(newOrder);
          var response = OrderFactory.Create(newOrder);
          return response;
        }

        public Task<OrderResponseModel> DeleteOrder(int customerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderResponseModel>> GetAllOrders()
        {
            var allProducts = (await this.orderRepository.GetAsync(x => x.IsDeleted == false)).ToList();
            var responseModels = allProducts.Select(x => OrderFactory.Create(x));
            return responseModels; 
        }

        public async Task<OrderResponseModel> GetSingleOrder(int OrderId)
        {
            var order = await this.orderRepository.GetByIdAsync(OrderId);
            if (order == null || order.IsDeleted)
            {
                throw new Exception("Order not found");
            }

            var response = OrderFactory.Create(order);
            return response;
        }

        public async Task<OrderResponseModel> UpdateOrder(int OrderId,OrderRequestModel orderRequest)
        {
            var updateOrder = await this.orderRepository.GetByIdAsync(OrderId);
            updateOrder.CustomerId = orderRequest.customerId;
            await this.productRepository.UpdateAsync(updateProduct);
            var response = ProductFactory.Create(updateProduct);
            return response;
        }
    }
}
