using Azure.Core;
using ECA.Core.Models;
using ECA.Infrastructure.Factories;
using ECA.Infrastructure.Repositories;
using ECA.ViewModels.RequestModel;
using ECA.ViewModels.ResponseModel;
using ECA.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.Services.ProductService
{
    public class ProductService:IProductService
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

        public Task<SuccessResponseModel> DeleteProduct(int customerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductResponseModel>> GetAllProducts()
        {
            var allProducts = (await this.productRepository.GetAsync(x => x.IsDeleted == false)).ToList();
            var responseModels = allProducts.Select(x => ProductFactory.Create(x));
            return responseModels;
        }

        public async Task<ProductResponseModel> GetSingleProduct(int productId)
        {
            var product = await this.productRepository.GetByIdAsync(productId);
            if (product == null)
            {
                throw new Exception("Product not found");
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
