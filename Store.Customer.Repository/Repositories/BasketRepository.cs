using StackExchange.Redis;
using Store.Customer.Core.Entity;
using Store.Customer.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Customer.Repository.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database=redis.GetDatabase();
        }
        public async Task<bool> DeleteBasketAsyn(string basketid)
        {
            return await _database.KeyDeleteAsync(basketid);
        }

        public async Task<CustomerBasket?> GetBasketAsyc(string basketid)
        {
           var basket= await _database.StringGetAsync(basketid);
            return basket.IsNullOrEmpty ?null :JsonSerializer.Deserialize<CustomerBasket>(basket);
        }

        public async Task<CustomerBasket?> UpdateBasketAsyc(CustomerBasket basket)
        {
          var res= await _database.StringSetAsync(basket.Id,JsonSerializer.Serialize(basket),TimeSpan.FromDays(20));
            if (res is false) return null;
            return await GetBasketAsyc(basket.Id);
        }
    }
}
