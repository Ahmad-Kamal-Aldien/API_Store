using AutoMapper;
using Store.Customer.Core.DTOS.Products;
using Store.Customer.Core.Entity;
using Store.Customer.Core.IRepositories;
using Store.Customer.Core.IServices.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Customer.Service.Services
{
    public class ProductServices : IProductServices
    {
        IMapper _mapper;
        IUnitOfWork _unitOfWork;
        public ProductServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async  Task<IEnumerable<BrandTypeDTOS>> GetAllBrand()
        {
            return _mapper.Map<IEnumerable<BrandTypeDTOS>>(await _unitOfWork.Repository<ProductBrand,int>().GetAllAsync());
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProduct()
        {
            return _mapper.Map<IEnumerable<ProductDTO>>(await _unitOfWork.Repository<Product, int>().GetAllAsync());
          
        }

        public async Task<IEnumerable<BrandTypeDTOS>> GetAllType()
        {
            return _mapper.Map<IEnumerable<BrandTypeDTOS>>(await _unitOfWork.Repository<ProductBrand, int>().GetAllAsync());

        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var product=await _unitOfWork.Repository<Product,int>().GetAsync(id);
            var map=_mapper.Map<ProductDTO>(product);
            return map;
        }
    }
}
