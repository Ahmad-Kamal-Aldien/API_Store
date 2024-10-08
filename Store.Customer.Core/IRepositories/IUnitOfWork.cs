using Store.Customer.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Customer.Core.IRepositories
{
    public interface IUnitOfWork
    {

        //Create Only Sp
        //To One Return When Call
        IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;


        //To Save Changes
        Task<int> CompleteAsync();
    }
}
