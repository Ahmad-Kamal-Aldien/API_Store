using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Customer.Core.IServices.Product;

namespace Store.Customer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductServices _productServices;
        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var products=await _productServices.GetAllProduct();
            return Ok(products);
        }

        [HttpGet("Brands")]
        public async Task<IActionResult> GetAllBrands()
        {
            var Brand = await _productServices.GetAllBrand();
            return Ok(Brand);
        }

        [HttpGet("Types")]
        public async Task<IActionResult> GetAllTypes()
        {
            var Type = await _productServices.GetAllType();
            return Ok(Type);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int? id)
        {
            if (id is null) return BadRequest("No Id ");
            var product=await _productServices.GetProductById(id.Value);
            if (product is null) return NotFound();
            return Ok(product);
        }
    }
}
