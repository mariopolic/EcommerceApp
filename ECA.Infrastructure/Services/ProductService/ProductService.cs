using AutoMapper;
using ECA.Core.Exceptions;
using ECA.Core.Models;
using ECA.Infrastructure.Factories;
using ECA.Infrastructure.Repositories;
using ECA.Infrastructure.RequestModel;
using ECA.ViewModels.RequestModel;
using ECA.ViewModels.ResponseModel;

namespace ECA.Infrastructure.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        public ProductService(IProductRepository productRepository,IMapper mapper)
        {

            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<ProductResponseModel> AddProduct(ProductRequestModel productRequest)
        {
            var newProduct = ProductFactory.Create(productRequest);
            await this.productRepository.AddAsync(newProduct);
            var response = ProductFactory.Create(newProduct);
            return response;
        }

        public async Task<SuccessResponseModel> DeleteProduct(int productId)
        {
            var chosenProduct = await this.productRepository.GetByIdAsync(productId);
            if (chosenProduct != null && chosenProduct.IsDeleted == false)
            {
                chosenProduct.IsDeleted = true;
                await this.productRepository.UpdateAsync(chosenProduct);
                return new SuccessResponseModel() { Success = chosenProduct.IsDeleted };
            }
            return new SuccessResponseModel() { Success = false };
        }

        public async Task<IEnumerable<ProductResponseModel>> GetAllProducts(int pageSize, int pageNumber)
        {
            var allProducts = await this.productRepository.GetAsync(x => x.IsDeleted == false);
            var paginatedProducts = allProducts.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            var responseModels = paginatedProducts.Select(c => ProductFactory.Create(c));
            return responseModels;
        }


        public async Task<IEnumerable<ProductResponseModel>> GetProductByPriceRange(ProductPriceRangeRequestModel productPriceRangeRequest)
        {
            var allProducts = await this.productRepository.GetAsync(x => x.ProductPrice >= productPriceRangeRequest.MinPrice && x.ProductPrice <= productPriceRangeRequest.MaxPrice);
            var responseModels = allProducts.Select(x=>ProductFactory.Create(x));
            return responseModels;
        }

        public async Task<IEnumerable<ProductResponseModel>> GetProductByTitle(string title)
        {
           var allProducts = await this.productRepository.GetAsync(x=>x.ProductName.Equals(title));
           var responseModels = allProducts.Select(x => ProductFactory.Create(x));
            return responseModels;  
        }

        public async Task<ProductResponseModel> GetSingleProduct(int productId)
        {
           var singleProduct = await this.productRepository.GetByIdAsync(productId);
           var responseModel = ProductFactory.Create(singleProduct);
           return responseModel;
        }

        public async Task<ProductResponseModel> UpdateProduct(int productId, ProductRequestModel productRequest)
        {
            var singleProduct = await this.productRepository.GetByIdAsync(productId);
            if (singleProduct != null && singleProduct.IsDeleted != true)
            {
                mapper.Map(productRequest, singleProduct);
                await this.productRepository.UpdateAsync(singleProduct);
                var response = ProductFactory.Create(singleProduct); 
                return response;
            }
            return new ProductResponseModel() { };
        }
    }
}
