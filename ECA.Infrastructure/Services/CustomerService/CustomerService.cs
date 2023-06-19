using ECA.Core.Exceptions;
using ECA.Core.Models;
using ECA.Infrastructure.Factories;
using ECA.Infrastructure.Repositories;
using ECA.ViewModels.ResponseModel;
using ECA.ViewModels.ViewModels;

namespace ECA.Infrastructure.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository CustomerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            CustomerRepository = customerRepository;
        }

        public async Task<CustomerResponseModel> AddCustomer(CustomerRequestModel customer)
        {
            var newCustomer = CustomerFactory.Create(customer);
            await this.CustomerRepository.AddAsync(newCustomer);
            var response = CustomerFactory.Create(newCustomer);
            return response;
        }

        public Task<SuccessResponseModel> DeleteCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerResponseModel>> GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerResponseModel> GetSingleCustomer(int customerid)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerResponseModel> UpdateCustomer(int customerId, CustomerRequestModel request)
        {
            throw new NotImplementedException();
        }
    }
}
