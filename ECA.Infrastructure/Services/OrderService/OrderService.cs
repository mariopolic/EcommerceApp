using ECA.Core.Exceptions;
using ECA.Core.Models;
using ECA.Infrastructure.Factories;
using ECA.Infrastructure.Repositories;
using ECA.ViewModels.RequestModel;
using ECA.ViewModels.ResponseModel;

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
            var customer = await this.customerRepository.GetByIdAsync(customerId);
            var newOrder = OrderFactory.Create(customer.Id);
            await this.orderRepository.AddAsync(newOrder);
            var response = OrderFactory.Create(newOrder);
            return response;
        }

        public Task<SuccessResponseModel> DeleteOrder(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderResponseModel>> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderResponseModel>> GetAllOrdersFromCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderResponseModel> GetSingleOrder(int OrderId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderResponseModel> UpdateOrder(int OrderId, OrderRequestModel orderRequest)
        {
            throw new NotImplementedException();
        }

        public Task<SuccessResponseModel> UpdateOrderPrice(int OrderId)
        {
            throw new NotImplementedException();
        }
    }
}
