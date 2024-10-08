using Store.Customer.Core.DTOS.Products;
using Store.Customer.Core.Helper;
using Store.Customer.Core.Specifications.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Customer.Core.IServices.Product
{
    public interface IProductServices
    {
        Task<PaginationResponse<ProductDTO>> GetAllProduct(ProductSpecParameter productSpecParameter);
        Task<IEnumerable<BrandTypeDTOS>> GetAllType();
        Task<IEnumerable<BrandTypeDTOS>> GetAllBrand();

        Task<ProductDTO> GetProductById(int id);


    }
}
