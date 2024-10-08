using Store.Customer.Core.Entity;
using Store.Customer.Core.ISpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Customer.Core.IRepositories
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllSpecificAsync(ISpecifications<TEntity, TKey> specifications);
        Task<TEntity> GetAsync(TKey id);
        Task<TEntity> GetWithSpecificAsync(ISpecifications<TEntity, TKey> specifications);

        Task<int> GetCountAsync(ISpecifications<TEntity,TKey> specifications);

        
         Task  AddAsync(TEntity entity);
        void  Update(TEntity entity);
        void Delete(TEntity key);
    }
}
