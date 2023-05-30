using ECA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.Repositories
{
    public interface ICustomerRepository:IRepository<Customer>
    {
        Task<Customer> GetByIdAsync(int id);
        Task<Customer> GetByNameAsync(string name);
        Task<Customer> GetByCityAsync(string city);
    }
}
