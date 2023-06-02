﻿using ECA.Core.Models;
using ECA.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.Repositories.EF_Core
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly EcommerceAppContext ecommerceAppContext;
        public OrderRepository(EcommerceAppContext ecommerceAppContext) : base(ecommerceAppContext)
        {
            this.ecommerceAppContext = ecommerceAppContext;
        }

        public async Task<Order> GetByCustomerAsync(int Customerid)
        {
            return await GetOrders().FirstOrDefaultAsync(c=>c.CustomerId == Customerid);
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await GetOrders().FirstOrDefaultAsync(o => o.Id == id);
        }
        private IQueryable<Order> GetOrders()
        {
            return this.ecommerceAppContext.Orders;
        }
    }
}