using Microsoft.EntityFrameworkCore;
using Store.Customer.Core.Entity;
using Store.Customer.Core.IRepositories;
using Store.Customer.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Customer.Repository.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        StoreDBContext _storeDBContext;
        public GenericRepository(StoreDBContext storeDBContext)
        {
            _storeDBContext=storeDBContext;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _storeDBContext.AddAsync(entity);
          
        }

        public void Delete(TEntity key)
        {
            _storeDBContext.Remove(key);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
     
            //With Navigation Property

            //Temporary solution

            if (typeof(TEntity) == typeof(Product))
            {
                return (IEnumerable<TEntity>) await _storeDBContext.Product.Include(x=>x.Brand).Include(x=>x.Type).ToListAsync();

            }

            //Without Navigation Property 
            return await  _storeDBContext.Set<TEntity>().ToListAsync();

            
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            if (typeof(TEntity) == typeof(Product))
            {
                return await _storeDBContext.Product.Include(x => x.Brand).Include(x => x.Type).FirstOrDefaultAsync(x=>x.Id==id as int?)as TEntity;

            }

            return await _storeDBContext.Set<TEntity>().FindAsync(id);
        }

        public void Update(TEntity entity)
        {
           _storeDBContext.Update(entity);
        }
    }
}
