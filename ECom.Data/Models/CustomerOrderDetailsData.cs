using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Data.Models
{
    public class CustomerOrderDetailsData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime DeliveryExpected { get; set; }
        public bool ContainsGift { get; set; } 
    }
}
