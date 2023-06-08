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
            Customer customer = await this.customerRepository.GetByIdAsync(customerId);
            if (customer == null)
            {
                throw new Exception("Customer does not exist!");
            }
            Order newOrder = OrderFactory.Create(customerId);
            await this.orderRepository.AddAsync(newOrder);
            var response = OrderFactory.Create(newOrder);
            return response;
        }

        public async Task<SuccessResponseModel> DeleteOrder(int orderId)
        {
            Order deleteOrder = await this.orderRepository.GetByIdAsync(orderId);
            if (deleteOrder == null)
                throw new EntityNotFoundException("Order does not exist!");

            deleteOrder.IsDeleted = true;
            await this.orderRepository.UpdateAsync(deleteOrder);
            return new SuccessResponseModel() { Success = deleteOrder.IsDeleted };
        }

        public async Task<IEnumerable<OrderResponseModel>> GetAllOrders()
        {
            var allOrders = (await this.orderRepository.GetAsync(x => x.IsDeleted == false && x.Customer.IsDeleted == false)).ToList();
            var responseModels = allOrders.Select(x => OrderFactory.Create(x));
            return responseModels;
        }

        public async Task<IEnumerable<OrderResponseModel>> GetAllOrdersFromCustomer(int customerId)
        {
            var allOrders = (await this.orderRepository.GetAsync(x => x.IsDeleted == false && x.CustomerId == customerId)).ToList();
            var responseModels = allOrders.Select(x => OrderFactory.Create(x));
            return responseModels;
        }

        public async Task<OrderResponseModel> GetSingleOrder(int OrderId)
        {
            var order = await this.orderRepository.GetByIdAsync(OrderId);
            if (order == null || order.IsDeleted)
            {
                throw new EntityNotFoundException("Order not found");
            }

            var response = OrderFactory.Create(order);
            return response;
        }

        public async Task<OrderResponseModel> UpdateOrder(int OrderId, OrderRequestModel orderRequest)
        {
            var updateOrder = await this.orderRepository.GetByIdAsync(OrderId);
            updateOrder.CustomerId = orderRequest.customerId;
            await this.orderRepository.UpdateAsync(updateOrder);
            var response = OrderFactory.Create(updateOrder);
            return response;
        }
        public async Task<SuccessResponseModel> UpdateOrderPrice(int OrderId)
        {
            var updateOrder = await this.orderRepository.GetByIdAsync(OrderId);
            await this.orderRepository.UpdateAsync(updateOrder);
            return new SuccessResponseModel() { Success = true };
        }
    }
}
