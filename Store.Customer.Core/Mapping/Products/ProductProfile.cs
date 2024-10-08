using AutoMapper;
using Microsoft.Extensions.Configuration;
using Store.Customer.Core.DTOS.Products;
using Store.Customer.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Customer.Core.Mapping.Products
{
    public class ProductProfile:Profile
    {
        public ProductProfile(IConfiguration configure)
        {
            CreateMap<Product, ProductDTO>()
         .ForMember(x => x.productBrandName, options => options.MapFrom(x => x.Brand.Name))
         .ForMember(x => x.productTypeName, options => options.MapFrom(x => x.Type.Name))
         .ForMember(x => x.PictureUrl, options => options.MapFrom(new PictureUrlResolver(configure)));
            CreateMap<ProductBrand, BrandTypeDTOS>();
            CreateMap<ProductType, BrandTypeDTOS>();
        }
     
    }
}
