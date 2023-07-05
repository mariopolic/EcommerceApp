using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECA.Infrastructure.RequestModel
{
    public class ProductPriceRangeRequestModel
    {
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
    }
}
