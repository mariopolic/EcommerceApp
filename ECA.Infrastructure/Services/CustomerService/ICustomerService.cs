using ECA.Core.Models;
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
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponseModel>> GetAllCustomers();
        Task<CustomerResponseModel> GetSingleCustomer(int customerid);
        Task<CustomerResponseModel> AddCustomer(CustomerRequestModel customer);
        Task<CustomerResponseModel> UpdateCustomer(int customerId, CustomerRequestModel request);
        Task<SuccessResponseModel> DeleteCustomer(int customerId);
    }
}
