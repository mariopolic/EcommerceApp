using ECA.Core.Models;
using ECA.ViewModels.RequestModel;
using ECA.ViewModels.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.Factories
{
    public class OrderItemFactory
    {
        public static OrderItemResponseModel Create(OrderItem order)
        {
            var product = ProductFactory.Create(order.Product);
            var orders = new OrderItemResponseModel() { 
                Price = product.ProductPrice * order.Quantity, 
                Quantity = order.Quantity, 
                Product = product 
            };
                return orders;
        }

        public static OrderItem Create(OrderItemRequestModel orderItemRequest,int order)
        {
            return new OrderItem() 
            { 
                ProductId = orderItemRequest.ProductId, 
                Price = orderItemRequest.Price, 
                Quantity = orderItemRequest.Quantity, 
                OrderId = order,
            };
        } 
        public static ICollection<OrderItemResponseModel> Create(IEnumerable<OrderItem> orders)
        {
            var responseModels = new List<OrderItemResponseModel>();
            if(orders != null)
            {
                foreach (var order in orders)
                {
                    var orderItemResponse = OrderItemFactory.Create(order);
                    if(order.IsDeleted == false)
                    {
                      responseModels.Add(orderItemResponse);
                    }
                }

                return responseModels;
            }
            return new List<OrderItemResponseModel>();
        }
    }
}
