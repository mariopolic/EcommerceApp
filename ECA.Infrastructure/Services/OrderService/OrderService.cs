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

        public async Task<SuccessResponseModel> DeleteOrder(int OrderId)
        {
            var chosenOrder = await this.orderRepository.GetByIdAsync(OrderId);
            if (chosenOrder != null && chosenOrder.IsDeleted == false)
            {
                chosenOrder.IsDeleted = true;
                await this.orderRepository.UpdateAsync(chosenOrder);
                return new SuccessResponseModel() { Success = chosenOrder.IsDeleted };
            }
            return new SuccessResponseModel() {Success = false};

        }

        public async Task<IEnumerable<OrderResponseModel>> GetAllOrders()
        {
            var allOrders = (await this.orderRepository.GetAsync(o => o.IsDeleted == false));
            var responseModels = allOrders.Select(c => OrderFactory.Create(c));
            return responseModels;
        }

        public async Task<IEnumerable<OrderResponseModel>> GetAllOrdersFromCustomer(int customerId)
        {
            var allOrders = (await this.orderRepository.GetAsync(o => o.IsDeleted == false && o.CustomerId == customerId));
            var responseModels = allOrders.Select(c => OrderFactory.Create(c)); 
            return responseModels;
        }

        public async Task<OrderResponseModel> GetSingleOrder(int OrderId)
        {
            var singleOrder = await this.orderRepository.GetByIdAsync(OrderId);
            if(singleOrder.IsDeleted != true )
            {
                var response = OrderFactory.Create(singleOrder);
                return response;
            }
            return new OrderResponseModel() { };
        }

        public async Task<OrderResponseModel> UpdateOrder(int OrderId, OrderRequestModel orderRequest)
        {
            var singleOrder = await this.orderRepository.GetByIdAsync(OrderId);
            if (singleOrder.IsDeleted != true )
            {
                singleOrder.CustomerId = orderRequest.customerId;
                await this.orderRepository.UpdateAsync(singleOrder);
            }
            return new OrderResponseModel() { };    
        }

     
    }
}
