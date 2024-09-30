using Store.Customer.Core.Entity;
using Store.Customer.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Customer.Repository.Data
{
    public static class StoreDBContextSeed
    {
     
        public async static Task SeedAsync(StoreDBContext _context)
        {
            if (_context.ProductBrand.Count() == 0)
            {
                var brands = File.ReadAllText(@"..\Store.Customer.Repository\Data\DataSeed\brands.json");

                var brand = JsonSerializer.Deserialize<List<ProductBrand>>(brands);

                if (brand != null && brand.Count() > 0)
                {
                    await _context.AddRangeAsync(brand);
                    await _context.SaveChangesAsync();

                }
            }

            if (_context.ProductType.Count() == 0)
            {
                var productsType = File.ReadAllText(@"..\Store.Customer.Repository\Data\DataSeed\types.json");

                var productType = JsonSerializer.Deserialize<List<ProductType>>(productsType);

                if (productType != null && productType.Count() > 0)
                {
                    await _context.AddRangeAsync(productType);
                    await _context.SaveChangesAsync();

                }
            }

            if (_context.Product.Count() == 0)
            {
                var Products = File.ReadAllText(@"..\Store.Customer.Repository\Data\DataSeed\products.json");

                var Product = JsonSerializer.Deserialize<List<Product>>(Products);

                if (Product != null && Product.Count() > 0)
                {
                    await _context.AddRangeAsync(Product);
                    await _context.SaveChangesAsync();

                }
            }


        }
    }
}
