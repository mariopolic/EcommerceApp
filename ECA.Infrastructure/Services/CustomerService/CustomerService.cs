using ECA.Core.Exceptions;
using ECA.Core.Models;
using ECA.Infrastructure.Factories;
using ECA.Infrastructure.Repositories;
using ECA.ViewModels.ResponseModel;
using ECA.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Customer updateCustomer = await this.CustomerRepository.GetByIdAsync(customerId);
            if (updateCustomer == null)
               throw new EntityNotFoundException("Customer does not exist!");
               
            updateCustomer.IsDeleted = true;
            await this.CustomerRepository.UpdateAsync(updateCustomer);
            return new SuccessResponseModel() { Success = updateCustomer.IsDeleted };
        }

        public async Task<IEnumerable<CustomerResponseModel>> GetAllCustomers()
        {
            var allCustomers = (await this.CustomerRepository.GetAsync(x=>x.IsDeleted == false)).ToList();
            var responseModels = allCustomers.Select(x => CustomerFactory.Create(x));
            return responseModels;
        }

        public async Task<CustomerResponseModel> GetSingleCustomer(int customerid)
        {
            var customer = await this.CustomerRepository.GetByIdAsync(customerid);

            CustomerResponseModel response = CustomerFactory.Create(customer);
            return response;
        }

        public async Task<CustomerResponseModel> UpdateCustomer(int customerId, CustomerRequestModel request)
        {
            var updateCustomer = await this.CustomerRepository.GetByIdAsync(customerId);
            updateCustomer.FirstName = request.FirstName;
            updateCustomer.LastName = request.LastName;
            updateCustomer.City = request.City;
            updateCustomer.Address = request.Address;
            await this.CustomerRepository.UpdateAsync(updateCustomer);
            var response = CustomerFactory.Create(updateCustomer);
            return response;
        }
    }
}
