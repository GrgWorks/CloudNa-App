using ECom.Application.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Models
{
    public class CustomerOrderDetails
    {
        public Customer.Customer Customer { get; set; }
        public Order.Order Order { get; set; }
    }
}
