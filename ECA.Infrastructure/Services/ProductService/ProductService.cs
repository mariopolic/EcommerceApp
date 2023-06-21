using ECA.Core.Exceptions;
using ECA.Core.Models;
using ECA.Infrastructure.Factories;
using ECA.Infrastructure.Repositories;
using ECA.ViewModels.RequestModel;
using ECA.ViewModels.ResponseModel;

namespace ECA.Infrastructure.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<ProductResponseModel> AddProduct(ProductRequestModel productRequest)
        {
            var newProduct = ProductFactory.Create(productRequest);
            await this.productRepository.AddAsync(newProduct);
            var response = ProductFactory.Create(newProduct);
            return response;
        }

        public Task<SuccessResponseModel> DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductResponseModel>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductResponseModel>> GetProductByPriceRange(int minPrice, int maxPrice)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductResponseModel>> GetProductByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponseModel> GetSingleProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponseModel> UpdateProduct(int productId, ProductRequestModel productRequest)
        {
            throw new NotImplementedException();
        }
    }
}
