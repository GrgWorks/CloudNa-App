using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Data.Models.OrderData
{
    public class OrderData
    {
        public List<ItemData.ItemData> OrderItems { get; set; }
    }
}
