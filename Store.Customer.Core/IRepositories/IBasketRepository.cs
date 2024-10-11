using Store.Customer.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Customer.Core.IRepositories
{
    public interface IBasketRepository
    {
        Task<CustomerBasket?> GetBasketAsyc(string basketid);
        Task<CustomerBasket?> UpdateBasketAsyc(CustomerBasket basket);
        Task<bool> DeleteBasketAsyn(string basketid);
    }
}
