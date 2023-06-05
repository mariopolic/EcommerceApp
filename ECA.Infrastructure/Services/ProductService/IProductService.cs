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
        Task<IEnumerable<ProductResponseModel>> GetAllProducts();
        Task<ProductResponseModel> GetSingleProduct(int productId );
        Task<ProductResponseModel> AddProduct(ProductRequestModel productRequest);
        Task<ProductResponseModel> UpdateProduct(int productId, ProductRequestModel productRequest);
        Task<IEnumerable<ProductResponseModel>> GetProductByTitle(string title);
        Task<IEnumerable<ProductResponseModel>> GetProductByPriceRange(int minPrice,int maxPrice);
        Task<SuccessResponseModel> DeleteProduct(int productId);
    }
}
