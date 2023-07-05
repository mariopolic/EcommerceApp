using ECA.Infrastructure.Factories;
using ECA.Infrastructure.Services.CustomerService;
using ECA.ViewModels.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace E_commerceApp.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly IValidator<CustomerRequestModel> Validator;

        public CustomerController(ICustomerService customerService,IValidator<CustomerRequestModel> validator)
        {
            this.customerService = customerService;
            Validator = validator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCustomers()
        {

            var customers = await customerService.GetAllCustomersAsync();
            return Ok(customers);
        }
        [HttpGet("get/{customerid}")]
        public async Task<IActionResult> GetSingleCustomer(int customerid)
        {
            var customer = await this.customerService.GetSingleCustomer(customerid);
            if (customer.FirstName == null && customer.LastName == null)
                return NotFound("Sorry but this customer does not exist");
            return Ok(customer);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerRequestModel customer)
        {
            var result = Validator.Validate(customer);
            if(!result.IsValid)
            {
                return BadRequest(result);
            }
           var newCustomer = await this.customerService.AddCustomer(customer);
           return Ok(newCustomer);
        }

        [HttpPut("update/{customerId}")]
        public async Task<IActionResult> UpdateCustomer(int customerId, [FromBody] CustomerRequestModel customerRequest)
        {
            var updatedCustomer = await this.customerService.UpdateCustomer(customerId, customerRequest);
            if(updatedCustomer == null)
            {
                return NotFound("Sorry but this customer does not exist");
            }
            return Ok(updatedCustomer);
        }

        [HttpGet("search/{filter}")]
        public async Task<IActionResult> SearchCustomer(string filter)
        {
            var searched = await this.customerService.SearchAllCustomersAsync(filter);
            if(searched == null)
            {
                return NotFound("Sorry but this customer does not exist");
            }
            return Ok(searched);
        }

        [HttpDelete("delete/{customerId}")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            var result = await this.customerService.DeleteCustomer(customerId);
            if (result == null)
                return NotFound("Sorry but this customer does not exist");
            return Ok(result);
        }
    }
}
