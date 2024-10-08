using Store.Customer.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Customer.Core.ISpecifications
{
    public interface ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        //db.product.where(x=>x.id==id).include(x=>x.Bradn);

        public Expression<Func<TEntity, bool>> Crtteria { get; set; }

        public List<Expression<Func<TEntity, object>>> Includes { get; set; }

        public Expression<Func<TEntity, object>> OrderBY { get; set; }
        public Expression<Func<TEntity, object>> OrderBYDesc { get; set; }


        public int Skip { get; set; }
        public int Take { get; set; }

        public bool IsPaginationaEnable { get; set; }



    }
}
