using ECA.Core.Models;

namespace ECA.Infrastructure.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetByIdAsync(int id);
        Task<Customer> GetByNameAsync(string name);
        Task<Customer> GetByCityAsync(string city);
    }
}
