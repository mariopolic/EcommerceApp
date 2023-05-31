using ECA.Core.Models;
using ECA.Infrastructure.Services.CustomerService;
using ECA.Infrastructure.Services.ProductService;
using ECA.ViewModels.RequestModel;
using ECA.ViewModels.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerceApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("GetAll")]
        public  IActionResult GetAllProducts()
        {
            string dummy = "test";
            return  Ok(dummy);
        }
        [HttpGet("get/{productid}")]
        public IActionResult GetSingleCustomer(int productid)
        {
            return Ok(productid);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddProduct([FromBody] ProductRequestModel productRequest)
           => Ok(await this._productService.AddProduct(productRequest));

        [HttpPut("update/{productId}")]
        public IActionResult UpdateCustomer(int productId, [FromBody] ProductRequestModel productRequest)
        {
            return Ok(productRequest);
        }

        [HttpDelete("delete/{productId}")]
        public  IActionResult DeleteCustomer(int productId)
        {
            return Ok(productId);
        }
    }
}
