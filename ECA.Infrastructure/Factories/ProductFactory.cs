using ECA.Core.Models;
using ECA.ViewModels.RequestModel;
using ECA.ViewModels.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.Factories
{
    public class ProductFactory
    {
        public static Product Create(ProductRequestModel productRequest)
        {
            return new Product() 
            { 
                ProductPrice = productRequest.ProductPrice,
                ProductName = productRequest.ProductName,
                ProductDescription = productRequest.ProductDescription,OrderItems = new List<OrderItem>() 
            };
        }

        public static ProductResponseModel Create(Product productResponse)
        {
            if (productResponse != null)
            {
                return new ProductResponseModel() 
                { 
                    ProductPrice = productResponse.ProductPrice, 
                    ProductName = productResponse.ProductName, 
                    ProductDescription = productResponse.
                    ProductDescription 
                };
            }
            return new ProductResponseModel();
        }
    }
}
