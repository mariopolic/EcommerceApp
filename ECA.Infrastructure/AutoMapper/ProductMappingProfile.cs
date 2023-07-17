using AutoMapper;
using ECA.Core.Models;
using ECA.ViewModels.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.AutoMapper
{
    public class ProductMappingProfile:Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductRequestModel, Product>()
           .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.ProductPrice))
           .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
           .ForMember(dest => dest.ProductDescription, opt => opt.MapFrom(src => src.ProductDescription));
        }
    }
}
