using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.ViewModels.ResponseModel
{
    public class OrderItemResponseModel
    {
        public ProductResponseModel Product { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
