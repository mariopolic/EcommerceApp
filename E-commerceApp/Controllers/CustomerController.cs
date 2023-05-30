using ECA.Core.Models;
using ECA.Infrastructure.Services.CustomerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace E_commerceApp.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
          this.customerService = customerService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCustomers()
        {   
            var customers = await customerService.GetAllCustomers();
            return Ok(customers);
        }
        [HttpGet("get/{customerId}")]
        public async Task<IActionResult> GetSingleCustomer(int customerid)
        {
         var customer = await this.customerService.GetSingleCustomer(customerid);
            if (customer == null)
                return NotFound("Sorry but this customer does not exist");
            return Ok(customer);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            var result = await customerService.AddCustomer(customer);
            return Ok(result);
        }
        [HttpPut("update/{customerId}")]
        public async Task<IActionResult> UpdateCustomer(int customerId, Customer request)
        {
          
            return Ok();
        }

        [HttpDelete("delete/{customerId}")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            var result = customerService.DeleteCustomer(customerId);
            if (result == null)
                return NotFound("Sorry but this customer does not exist");
            return Ok(result);
        }
    }
}
