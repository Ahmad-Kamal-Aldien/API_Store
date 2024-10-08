using AutoMapper;
using AutoMapper.Execution;
using Microsoft.Extensions.Configuration;
using Store.Customer.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Customer.Core.DTOS.Products
{
    public class PictureUrlResolver : IValueResolver<Product, ProductDTO, string>
    {
        private readonly IConfiguration _configuration;
        public PictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{_configuration["BaseURL"]}{source.PictureUrl}";
            }
            return string.Empty;

        }
    }
}
