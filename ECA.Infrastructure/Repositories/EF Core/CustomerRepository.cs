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
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private readonly EcommerceAppContext ecommerceAppContext;
        public CustomerRepository(EcommerceAppContext ecommerceAppContext):base(ecommerceAppContext)
        {
            this.ecommerceAppContext = ecommerceAppContext;
        }
        public async Task<Customer> GetByCityAsync(string city)
        {
            return await GetCustomers().FirstOrDefaultAsync(c=>c.City == city);
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await GetCustomers().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer> GetByNameAsync(string name)
        {
            return await GetCustomers().FirstOrDefaultAsync(c => c.FirstName == name);
        }

        public override async Task<IEnumerable<Customer>> GetAsync(Expression<Func<Customer, bool>> predicate)
        {
            return await GetCustomers().Where(predicate).ToListAsync();
        }
        private IQueryable<Customer> GetCustomers()
        {
            return this.ecommerceAppContext.Customers;
        }
    }
}
