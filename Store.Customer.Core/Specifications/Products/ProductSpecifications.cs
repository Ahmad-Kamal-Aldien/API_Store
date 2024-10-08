using Store.Customer.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Customer.Core.Specifications.Products
{
    public class ProductSpecifications:BaseSpecifications<Product,int>
    {
        public ProductSpecifications(int? id):base(x=>x.Id==id)
        {
            AddIncludes();

        }
        public ProductSpecifications(ProductSpecParameter productSpecParameter) :base(
           
            
            x=>
             (string.IsNullOrEmpty(productSpecParameter.Search)|| x.Name.ToLower().Contains(productSpecParameter.Search))
            &&
            (!productSpecParameter.Brandid.HasValue || productSpecParameter.Brandid == x.BrandId) 
            &&(!productSpecParameter.typeid.HasValue || productSpecParameter.typeid == x.TypeId)
            )
        {
            if (!string.IsNullOrEmpty(productSpecParameter.sort))
            {
                switch (productSpecParameter.sort)
                {
                    case "priceAsync":
                        AddOrderBy(x => x.Price);
                        break;
                    case "PriceDesc":
                        AddOrderByDesc(x => x.Price);
                        break;
                    default:
                        AddOrderBy(x=>x.Name );
                        break;
                }
            }
            else
            {
                AddOrderBy(x => x.Name);

            }
           
            AddIncludes();

            ApplayPagination(productSpecParameter.pagesize * (productSpecParameter.pageindex - 1), productSpecParameter.pagesize);
        }
        public void AddIncludes()
        {
            Includes.Add(x=>x.Brand);
            Includes.Add(x=>x.Type);
        }



    }
}
