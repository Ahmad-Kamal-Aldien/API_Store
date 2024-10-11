using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Customer.Core.Entity
{
    public class CustomerBasket
    {
        public string Id {  get; set; }

        public List<BasketEntity> basketEntities { get; set; }
         
    }
}
