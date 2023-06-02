using ECA.Core.Models;
using ECA.ViewModels.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.Factories
{
    public class OrderFactory
    {
        public static Order Create(int CustomerId)
        {
            var order = new Order() { CustomerId = CustomerId, OrderItems = new List<OrderItem>() };
            return order;
        }
        public static OrderResponseModel Create(Order order)
        {
            if (order != null)
            {
                var newOrders = OrderItemFactory.Create(order.OrderItems);
                var newCustomer = CustomerFactory.Create(order.Customer);
                var orderResponseModel = new OrderResponseModel() { CustomerId = order.CustomerId, OrderItems = newOrders };
                return orderResponseModel;
            }
           return new OrderResponseModel();
        }
    }
}
