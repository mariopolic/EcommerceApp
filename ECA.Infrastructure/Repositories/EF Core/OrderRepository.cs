using ECA.Core.Models;
using ECA.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.Repositories.EF_Core
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EcommerceAppContext ecommerceAppContext;
        public OrderRepository(EcommerceAppContext ecommerceAppContext)
        {
            this.ecommerceAppContext = ecommerceAppContext;
        }

        public async Task<Order> AddAsync(Order Order)
        {
            this.ecommerceAppContext.Orders.Add(Order);
            await this.ecommerceAppContext.SaveChangesAsync();
            return Order;
        }

        public async Task<IEnumerable<Order>> GetAsync(Expression<Func<Order, bool>> predicate)
        {
            return await GetOrders().Where(predicate).Include(c => c.OrderItems).ThenInclude(x=>x.Product).ToListAsync();
        }
        public async Task<Order> GetByCustomerAsync(int Customerid)
        {
            return await GetOrders().FirstOrDefaultAsync(c=>c.CustomerId == Customerid);
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await GetOrders().Include(x=>x.OrderItems).ThenInclude(x=>x.Product).FirstOrDefaultAsync(o => o.Id == id);
        }
        private IQueryable<Order> GetOrders()
        {
            return this.ecommerceAppContext.Orders.Include(c => c.Customer).Include(o => o.OrderItems);
        }
    }
}
