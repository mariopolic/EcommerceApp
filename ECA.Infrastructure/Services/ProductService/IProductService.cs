﻿using ECA.Infrastructure.RequestModel;
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
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseModel>> GetAllProducts(int pageSize, int pageNumber);
        Task<ProductResponseModel> GetSingleProduct(int productId );
        Task<ProductResponseModel> AddProduct(ProductRequestModel productRequest);
        Task<ProductResponseModel> UpdateProduct(int productId, ProductRequestModel productRequest);
        Task<IEnumerable<ProductResponseModel>> GetProductByTitle(string title);
        Task<IEnumerable<ProductResponseModel>> GetProductByPriceRange(ProductPriceRangeRequestModel productPriceRangeRequest);
        Task<SuccessResponseModel> DeleteProduct(int productId);
    }
}
