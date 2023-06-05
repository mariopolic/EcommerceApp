using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual int CustomerId { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public bool IsDeleted { get; set; } 
        public int OrderPrice { get; set; }
    }
}
