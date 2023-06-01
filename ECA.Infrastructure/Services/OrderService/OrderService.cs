using ECA.Core.Models;
using ECA.Infrastructure.Factories;
using ECA.Infrastructure.Repositories;
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

        public Task<IEnumerable<OrderResponseModel>> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Task<OrderResponseModel> GetSingleOrder(int OrderId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderResponseModel> UpdateOrder(int OrderId, int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
