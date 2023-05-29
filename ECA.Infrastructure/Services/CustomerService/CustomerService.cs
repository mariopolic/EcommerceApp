using ECA.Core.Models;
using ECA.ViewModels.ResponseModel;
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
        private static List<Customer> customers = new List<Customer>
        {
        new Customer {
            Id = 1,
            FirstName="Faruk",
            LastName="Sackin",
            City="Cazin",
            Address="Koliste"
        },  new Customer {
            Id = 2,
            FirstName="Zejnin",
            LastName="Mcgregor",
            City="Cazin",
            Address="Tartari"
        }
        };
        public Task<CustomerResponseModel> AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task<SuccessResponseModel> DeleteCustomer(int customerId, Customer request)
        {
            Customer updateCustomer = customers.Find(x => x.Id == customerId);
            if (updateCustomer == null)
               updateCustomer.IsDeleted = true;
            return new SuccessResponseModel() { Success = updateCustomer.IsDeleted };
        }

        public async Task<IEnumerable<CustomerResponseModel>> GetAllCustomers()
        {
            return new List<CustomerResponseModel>();
        }

        public async Task<CustomerResponseModel> GetSingleCustomer(int customerid)
        {
            return new CustomerResponseModel();
        }

        public async Task<CustomerResponseModel> UpdateCustomer(int customerId, Customer request)
        {
            var updateCustomer = customers.Find(x => x.Id == customerId);
            updateCustomer.FirstName = request.FirstName;
            updateCustomer.LastName = request.LastName;
            updateCustomer.City = request.City;
            updateCustomer.Address = request.Address;
            return new CustomerResponseModel();
        }
    }
}
