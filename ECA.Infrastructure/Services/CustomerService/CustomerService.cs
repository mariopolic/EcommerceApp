using AutoMapper;
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
        private readonly IMapper mapper;
        public CustomerService(ICustomerRepository customerRepository,IMapper Mapper)
        {
            CustomerRepository = customerRepository;
            mapper = Mapper;    
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

        public async Task<IEnumerable<CustomerResponseModel>> SearchAllCustomersAsync(string filter)
        {
            var allCustomers = await this.CustomerRepository.GetAllAsync();
            var filtered = allCustomers.Where(x=>x.FirstName.Equals(filter));
            var responseModels = filtered.Select(c => CustomerFactory.Create(c));
            return responseModels;
        }

        public async Task<CustomerResponseModel> UpdateCustomer(int customerId, CustomerRequestModel request)
        {
            
            var Customer = await this.CustomerRepository.GetByIdAsync(customerId);
            if(Customer != null)
            {
                mapper.Map(request,Customer);
                await this.CustomerRepository.UpdateAsync(Customer);
                var response = CustomerFactory.Create(Customer);
                return response;
            }
            return new CustomerResponseModel();
        }
    }
}
