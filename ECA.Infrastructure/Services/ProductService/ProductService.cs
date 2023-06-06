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
            Product newProduct = ProductFactory.Create(productRequest);
            await this.productRepository.AddAsync(newProduct);
            var response = ProductFactory.Create(newProduct);
            return response;
        }

        public async Task<SuccessResponseModel> DeleteProduct(int productId)
        {
            Product deleteProduct = await this.productRepository.GetByIdAsync(productId);
            if (deleteProduct == null)
                throw new EntityNotFoundException("Customer does not exist!");

            deleteProduct.IsDeleted = true;
            await this.productRepository.UpdateAsync(deleteProduct);
            return new SuccessResponseModel() { Success = deleteProduct.IsDeleted };
        }

        public async Task<IEnumerable<ProductResponseModel>> GetAllProducts()
        {
            var allProducts = (await this.productRepository.GetAsync(x => x.IsDeleted == false)).ToList();
            var responseModels = allProducts.Select(x => ProductFactory.Create(x));
            return responseModels;
        }

        public async Task<IEnumerable<ProductResponseModel>> GetProductByPriceRange(int minPrice, int maxPrice)
        {
            var allProducts = (await this.productRepository.GetAsync(x => x.IsDeleted == false && x.ProductPrice >= minPrice && x.ProductPrice <= maxPrice)).ToList();
            var responseModels = allProducts.Select(x => ProductFactory.Create(x));
            return responseModels;
        }

        public async Task<IEnumerable<ProductResponseModel>> GetProductByTitle(string title)
        {
            var allProducts = (await this.productRepository.GetAsync(x => x.IsDeleted == false && x.ProductName == title)).ToList();
            var responseModels = allProducts.Select(x => ProductFactory.Create(x));
            return responseModels;
        }

        public async Task<ProductResponseModel> GetSingleProduct(int productId)
        {
            var product = await this.productRepository.GetByIdAsync(productId);
            if (product == null || product.IsDeleted == true)
            {
                throw new EntityNotFoundException("Product not found");
            }
            ProductResponseModel response = ProductFactory.Create(product);
            return response;
        }

        public async Task<ProductResponseModel> UpdateProduct(int productId, ProductRequestModel productRequest)
        {
            var updateProduct = await this.productRepository.GetByIdAsync(productId);
            updateProduct.ProductName = productRequest.ProductName;
            updateProduct.ProductDescription = productRequest.ProductDescription;
            updateProduct.ProductPrice = productRequest.ProductPrice;
            await this.productRepository.UpdateAsync(updateProduct);
            var response = ProductFactory.Create(updateProduct);
            return response;
        }
    }
}
