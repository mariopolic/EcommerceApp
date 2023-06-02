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
        public Task<OrderItem> GetByCustomerAsync(int Customerid)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItem> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItem> GetByPrice(int price)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItem> GetByProductIdAsync(int productid)
        {
            throw new NotImplementedException();
        }
    }
}
