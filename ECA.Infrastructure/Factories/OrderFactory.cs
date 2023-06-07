using ECA.Core.Models;
using ECA.ViewModels.ResponseModel;

namespace ECA.Infrastructure.Factories
{
    public class OrderFactory
    {
        public static Order Create(int CustomerId)
        {
            var order = new Order()
            {
                CustomerId = CustomerId,
                OrderItems = new List<OrderItem>(),
            };
            var sum = order.OrderItems.Sum(x => x.Price);
            var total = sum * order.OrderItems.Count;
            order.OrderPrice = total;
            return order;
        }
        public static OrderResponseModel Create(Order order)
        {
            if (order != null)
            {
                var newOrders = OrderItemFactory.Create(order.OrderItems);
                var newCustomer = CustomerFactory.Create(order.Customer);
                var orderResponseModel = new OrderResponseModel() { CustomerId = order.CustomerId, OrderItems = newOrders, TotalOrderPrice = newOrders.Sum(x => x.Price),Customer = newCustomer };
                return orderResponseModel;
            }
            return new OrderResponseModel();
        }
    }
}
