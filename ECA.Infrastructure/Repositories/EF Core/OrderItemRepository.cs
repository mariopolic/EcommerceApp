using ECA.Core.Models;
using ECA.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.Repositories.EF_Core
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        private readonly EcommerceAppContext ecommerceAppContext;
        public OrderItemRepository(EcommerceAppContext ecommerceAppContext) : base(ecommerceAppContext)
        {
            this.ecommerceAppContext = ecommerceAppContext;
        }
        public async Task<OrderItem> GetByCustomerAsync(int Customerid)
        {
          return await GetOrderItems().FirstOrDefaultAsync(x=>x.Order.CustomerId == Customerid);
        }

        public async Task<OrderItem> GetByIdAsync(int id)
        {
            return await GetOrderItems().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<OrderItem> GetByPrice(int price)
        {
            return await GetOrderItems().FirstOrDefaultAsync(x => x.Price == price);
        }

        public async Task<OrderItem> GetByProductIdAsync(int productid)
        {
            return await GetOrderItems().FirstOrDefaultAsync(x => x.ProductId == productid);
        }
        private IQueryable<OrderItem> GetOrderItems()
        {
            return this.ecommerceAppContext.OrderItems;
        }
    }
}
