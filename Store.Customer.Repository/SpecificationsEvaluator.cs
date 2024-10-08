using Microsoft.EntityFrameworkCore;
using Store.Customer.Core.Entity;
using Store.Customer.Core.ISpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Customer.Repository
{
    public static class SpecificationsEvaluator<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        //1-_dbcontext.Product
        //2- .
        public static IQueryable<TEntity> BuildQuery(IQueryable<TEntity> main, ISpecifications<TEntity, TKey> specifications)
        {

            var query = main;
            if(specifications.Crtteria !=null)
            {
                query = query.Where(specifications.Crtteria);
            }

            
            if(specifications.OrderBY != null)
            {
                query = query.OrderBy(specifications.OrderBY);

            }
            if (specifications.OrderBYDesc != null)
            {
                query = query.OrderByDescending(specifications.OrderBYDesc);

            }

            if (specifications.IsPaginationaEnable)
            {
                query = query.Skip(specifications.Skip).Take(specifications.Take);
            }

            query = specifications.Includes.Aggregate(query, (current,query)=> current.Include(query));



            return query;
        }

    }
}
