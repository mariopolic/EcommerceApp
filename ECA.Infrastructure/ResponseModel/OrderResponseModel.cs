using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.ViewModels.ResponseModel
{
    public class OrderResponseModel
    {
        public CustomerResponseModel Customer { get; set; } 
        public virtual int CustomerId { get; set; }
        public ICollection<OrderItemResponseModel> OrderItems { get; set; }
        public int TotalOrderPrice { get; set; }
     
    }
}
