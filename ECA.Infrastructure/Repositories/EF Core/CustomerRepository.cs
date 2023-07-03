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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly EcommerceAppContext ecommerceAppContext;

        public CustomerRepository(EcommerceAppContext ecommerceAppContext)
        {
            this.ecommerceAppContext = ecommerceAppContext;
        }
        public async Task<Customer> GetByIdAsync(int id)
        {
            return await this.ecommerceAppContext.Customers.FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
        }

        public async Task<IEnumerable<Customer>> GetAsync(Expression<Func<Customer, bool>> predicate)
        {
            return await this.ecommerceAppContext.Customers.Where(predicate).ToListAsync();
        }
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await this.ecommerceAppContext.Customers.Where(c => !c.IsDeleted).ToListAsync();
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            this.ecommerceAppContext.Customers.Add(customer);
            await this.ecommerceAppContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            this.ecommerceAppContext.Customers.Update(customer);
            await this.ecommerceAppContext.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteAsync(Customer customer)
        {
            this.ecommerceAppContext.Customers.Remove(customer);
            await this.ecommerceAppContext.SaveChangesAsync();
        }
    }
}


   
   

