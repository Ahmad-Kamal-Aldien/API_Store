using Store.Customer.Core.Entity;
using Store.Customer.Core.IRepositories;
using Store.Customer.Repository.Contexts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Customer.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
      private  StoreDBContext _storeDBContext;

        //Store All Used Repository To Used It
        private Hashtable _usedRepository;
        public UnitOfWork(StoreDBContext storeDBContext)
        {
            _storeDBContext = storeDBContext;
            _usedRepository=new Hashtable();
        }
        public async Task<int> CompleteAsync()
        {
          return await  _storeDBContext.SaveChangesAsync();
        }

        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            //var type=typeof(TEntity);
            var type = typeof(TEntity).Name;


            if (!_usedRepository.ContainsKey(type)) {
                var repository = new GenericRepository<TEntity, TKey>(_storeDBContext);
                _usedRepository.Add(type, repository);
                
            
            }
            return _usedRepository[type] as IGenericRepository<TEntity, TKey>;
        }
    }
}
