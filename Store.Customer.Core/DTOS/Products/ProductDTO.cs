using Store.Customer.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Customer.Core.DTOS.Products
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }


        public int? productBrandid { get; set; }
        public string productBrandName { get; set; }

        public int? productTypeid { get; set; }

        public string productTypeName { get; set; }
    }
}
