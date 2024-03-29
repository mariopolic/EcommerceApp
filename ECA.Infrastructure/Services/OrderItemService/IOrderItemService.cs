﻿using ECA.Core.Models;
using ECA.ViewModels.RequestModel;
using ECA.ViewModels.ResponseModel;
using ECA.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.Services.OrderItemService
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemResponseModel>> GetAllOrderItems();
        Task<OrderItemResponseModel> GetSingleOrderItem(int OrderId);
        Task<OrderItemResponseModel> AddOrderItem(int customerId,int orderId, OrderItemRequestModel orderItemRequest);
        Task<OrderItemResponseModel> UpdateOrderItem(int OrderId, OrderItemRequestModel orderRequest);
        Task<SuccessResponseModel> DeleteOrderItem(int orderId);
    }
}
