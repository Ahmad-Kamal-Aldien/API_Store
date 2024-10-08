using Store.Customer.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Customer.Core.Specifications.Products
{
    public class ProductCountSpecifications:BaseSpecifications<Product,int>
    {
        public ProductCountSpecifications(ProductSpecParameter productSpecParameter) : base(

          x =>
          (string.IsNullOrEmpty(productSpecParameter.Search) || x.Name.ToLower().Contains(productSpecParameter.Search))
            &&
          (!productSpecParameter.Brandid.HasValue || productSpecParameter.Brandid == x.BrandId)
          && (!productSpecParameter.typeid.HasValue || productSpecParameter.typeid == x.TypeId)
          )
        {
           
        }
    }
}
