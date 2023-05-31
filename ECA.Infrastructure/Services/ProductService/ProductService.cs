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

        public Task<IEnumerable<ProductResponseModel>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponseModel> GetSingleProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponseModel> UpdateProduct(int customerId, CustomerRequestModel productRequest)
        {
            throw new NotImplementedException();
        }
    }
}
