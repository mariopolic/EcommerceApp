using ECA.Infrastructure.Factories;
using ECA.Infrastructure.Services.ProductService;
using ECA.ViewModels.RequestModel;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace E_commerceApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService ProductService;
        private readonly IValidator<ProductRequestModel> Validator;
        public ProductController(IProductService productService, IValidator<ProductRequestModel> validator)
        {
            ProductService = productService;
            Validator = validator;
        }
        [HttpGet("GetAll/{pageSize}/{pageNumber}")]
        public async Task<IActionResult> GetAllProducts(int pageSize, int pageNumber)
        {
            var products = await ProductService.GetAllProducts(pageSize, pageNumber);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }
        [HttpGet("get/{productid}")]
        public async Task<IActionResult> GetSingleProduct(int productid)
        {
            var product = await ProductService.GetSingleProduct(productid);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet("getbytitle/{productTitle}")]
        public async Task<IActionResult> GetProductbyTitle(string productTitle)
        {
            return Ok(await this.ProductService.GetProductByTitle(productTitle));
        }

        [HttpGet("getbypricerange/From/{minPrice}/To/{maxPrice}")]
        public async Task<IActionResult> GetProductsbyPriceRange(int minPrice, int maxPrice)
        {
            return Ok(await this.ProductService.GetProductByPriceRange(minPrice, maxPrice));
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddProduct([FromBody] ProductRequestModel productRequest)
        {
            var result = Validator.Validate(productRequest);
            if (!result.IsValid)
            {
                return BadRequest(result);
            }
            var newProduct = await this.ProductService.AddProduct(productRequest);
            return Ok(newProduct);
        }

        [HttpPut("update/{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, [FromBody] ProductRequestModel productRequest)
        {
            return Ok(await this.ProductService.UpdateProduct(productId, productRequest));
        }

        [HttpDelete("delete/{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var result = await this.ProductService.DeleteProduct(productId);
            if (result == null)
                return NotFound("Sorry but this product does not exist");
            return Ok(result);
        }
    }
}
