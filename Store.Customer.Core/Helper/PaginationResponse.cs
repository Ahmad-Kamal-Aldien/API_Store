using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Customer.Core.Helper
{
    public class PaginationResponse<TEntity>
    {
        public PaginationResponse(int pageSize, int pageIndex, int count, IEnumerable<TEntity> items)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            Count = count;
            Items = items;
        }

        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int Count { get; set; }

        public IEnumerable<TEntity> Items { get; set;}
    }
}
