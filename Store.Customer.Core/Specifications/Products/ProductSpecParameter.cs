using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Customer.Core.Specifications.Products
{
    public class ProductSpecParameter
    {
        private string? search;

        public string? Search
        {
            get { return search; }
            set { search = value?.ToLower(); }
        }

        public string? sort { get; set; }
        public int? Brandid { get; set; }
        public int? typeid { get; set; }
        public int pagesize { get; set; } = 5;
        public int pageindex { get; set; } = 1;
    }
}
