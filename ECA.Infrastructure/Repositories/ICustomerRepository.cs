using ECA.Core.Models;

namespace ECA.Infrastructure.Repositories
{
    public interface ICustomerRepository 
    {
        Task<Customer> GetByIdAsync(int id);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> AddAsync(Customer customer);
        Task<Customer> UpdateAsync(Customer customer);
        Task DeleteAsync(Customer customer);
    }
}
