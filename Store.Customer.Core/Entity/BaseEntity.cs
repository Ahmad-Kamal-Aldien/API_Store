using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Customer.Core.Entity
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}
