using Store.Customer.Core.Entity;
using Store.Customer.Core.ISpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Store.Customer.Core.Specifications
{
    public class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public BaseSpecifications()
        {
            
        }
        public BaseSpecifications(Expression<Func<TEntity, bool>> _Crtteria)
        {
            Crtteria= _Crtteria;
        }
        public Expression<Func<TEntity, bool>> Crtteria
        {

            get; set;
        }
        public List<Expression<Func<TEntity, object>>> Includes
        {
            get; set;


        } = new List<Expression<Func<TEntity, object>>>();
        public Expression<Func<TEntity, object>> OrderBY { get; set; }
        public Expression<Func<TEntity, object>> OrderBYDesc { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPaginationaEnable { get; set; }

        public void AddOrderBy(Expression<Func<TEntity, object>> expression)
        {
            OrderBY = expression;
        }


        public void ApplayPagination(int skip,int take)
        {
            IsPaginationaEnable = true;
            Skip = skip;
            Take = take;

        }
        public void AddOrderByDesc(Expression<Func<TEntity, object>> expression)
        {
            OrderBYDesc = expression;
        }



    }
}
