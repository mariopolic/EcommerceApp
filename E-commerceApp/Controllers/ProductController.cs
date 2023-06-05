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
        public async  Task<IActionResult> GetAllProducts()
        {
            var products = await  _productService.GetAllProducts();
            if(products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }
        [HttpGet("get/{productid}")]
        public async Task<IActionResult> GetSingleCustomer(int productid)
        {
            var product = await _productService.GetSingleProduct(productid);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet("getbytitle/{productTitle}")]
        public async Task<IActionResult> GetProductbyTitle(string productTitle)
        {
            return Ok(await this._productService.GetProductByTitle(productTitle));
        }

        [HttpGet("getbypricerange/From/{minPrice}/To/{maxPrice}")]
        public async Task<IActionResult> GetProductsbyPriceRange(int minPrice, int maxPrice)
        {
            return Ok(await this._productService.GetProductByPriceRange(minPrice, maxPrice));
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddProduct([FromBody] ProductRequestModel productRequest)
           => Ok(await this._productService.AddProduct(productRequest));

        [HttpPut("update/{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, [FromBody] ProductRequestModel productRequest)
        {
            return Ok(await this._productService.UpdateProduct(productId, productRequest));
        }

        [HttpDelete("delete/{productId}")]
        public  async Task<IActionResult> DeleteProduct(int productId)
        {
            var result = await this._productService.DeleteProduct(productId);
            if (result == null)
                return NotFound("Sorry but this product does not exist");
            return Ok(result);
        }
    }
}
