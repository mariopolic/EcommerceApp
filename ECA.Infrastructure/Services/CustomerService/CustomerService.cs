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

        public async Task<SuccessResponseModel> DeleteCustomer(int customerId)
        {
            var chosenCustomer = await this.CustomerRepository.GetByIdAsync(customerId);
            if (chosenCustomer != null)
            {
                chosenCustomer.IsDeleted = true;
                await this.CustomerRepository.UpdateAsync(chosenCustomer);
                return new SuccessResponseModel() { Success = chosenCustomer.IsDeleted };
            }
            return new SuccessResponseModel() { Success = false };
        }

        public async Task<IEnumerable<CustomerResponseModel>> GetAllCustomersAsync()
        {
            var allCustomers = await this.CustomerRepository.GetAllAsync();
            var responseModels = allCustomers.Select(c => CustomerFactory.Create(c));
            return responseModels;
        }

        public async Task<CustomerResponseModel> GetSingleCustomer(int customerid)
        {
            var Customer = await this.CustomerRepository.GetByIdAsync(customerid);
            var response = CustomerFactory.Create(Customer);
            return response;
        }

        public async Task<CustomerResponseModel> UpdateCustomer(int customerId, CustomerRequestModel request)
        {
            
            var Customer = await this.CustomerRepository.GetByIdAsync(customerId);
            if(Customer != null)
            {
                Customer.FirstName = request.FirstName;
                Customer.LastName = request.LastName;
                Customer.Address = request.Address;
                Customer.City = request.City;
                await this.CustomerRepository.UpdateAsync(Customer);
                var response = CustomerFactory.Create(Customer);
                return response;
            }
            return new CustomerResponseModel();
        }
    }
}
