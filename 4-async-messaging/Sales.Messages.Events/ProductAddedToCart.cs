using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Messages.Events
{
    public interface ProductAddedToCart
    {
        int CartId { get; set; }
        int ProductId{ get; set; }
    }
}
