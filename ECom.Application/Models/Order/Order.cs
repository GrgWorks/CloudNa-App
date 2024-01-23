
using ECom.Application.Models.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Models.Order
{
    public class Order
    {
        public int? OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? DeliveryAdress { get; set; }
        public List<Item.Item> OrderItems { get; set; }
        public DateTime? DeliveryExpected { get; set; }

    }
}
