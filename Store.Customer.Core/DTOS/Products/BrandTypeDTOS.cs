using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Customer.Core.DTOS.Products
{
    public class BrandTypeDTOS
    {
        public string Name { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;

    }
}
