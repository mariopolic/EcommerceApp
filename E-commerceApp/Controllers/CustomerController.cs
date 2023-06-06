using ECA.Infrastructure.Services.CustomerService;
using ECA.ViewModels.ViewModels;
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
            => Ok(await this.customerService.AddCustomer(customer));

        [HttpPut("update/{customerId}")]
        public async Task<IActionResult> UpdateCustomer(int customerId, [FromBody] CustomerRequestModel customerRequest)
        {
            return Ok(await this.customerService.UpdateCustomer(customerId, customerRequest));
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
