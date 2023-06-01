using ECA.Core.Models;
using ECA.ViewModels.ResponseModel;
using ECA.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.Factories
{
    public class CustomerFactory
    {
        public static Customer Create(CustomerRequestModel RequestModel)
        {
            return new Customer() { Address = RequestModel.Address, City = RequestModel.City, FirstName = RequestModel.FirstName, LastName = RequestModel.LastName, Order=new List<Order>() };
        }

        public static CustomerResponseModel Create(Customer customer)
        {
            if (customer != null)
            {
                return new CustomerResponseModel() { FirstName = customer.FirstName, LastName = customer.LastName, City = customer.City, Address = customer.Address };
            }
            return new CustomerResponseModel();
        }
    }
}
