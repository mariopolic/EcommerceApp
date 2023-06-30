using ECA.Core.Models;
using ECA.Infrastructure.Contexts;
using ECA.ViewModels.RequestModel;
using ECA.ViewModels.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.Repositories.EF_Core
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly EcommerceAppContext ecommerceAppContext;
        public OrderItemRepository(EcommerceAppContext ecommerceAppContext) 
        {
            this.ecommerceAppContext = ecommerceAppContext;
        }

        public async Task<OrderItem> AddAsync(OrderItem OrderItem)
        {
            this.ecommerceAppContext.OrderItems.Add(OrderItem);
            await this.ecommerceAppContext.SaveChangesAsync();
            return OrderItem;
        }

        public  async Task<IEnumerable<OrderItem>> GetAsync(Expression<Func<OrderItem, bool>> predicate)
        {
            return await GetOrderItems().Where(predicate).Include(c => c.Product).ToListAsync();
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

        public async Task<OrderItem> UpdateAsync( OrderItem orderItem)
        {
           this.ecommerceAppContext.Update(orderItem);
           this.ecommerceAppContext.SaveChanges();
            return orderItem;
        }

        private IQueryable<OrderItem> GetOrderItems()
        {
            return this.ecommerceAppContext.OrderItems.Include(x => x.Order).Include(x => x.Product);
        }
    }
}
