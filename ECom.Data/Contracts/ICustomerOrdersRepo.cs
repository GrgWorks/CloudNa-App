using ECom.Data.Models;
using ECom.Data.Models.ItemData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Data.Contracts
{
    public interface ICustomerOrdersRepo
    {
        CustomerOrderDetailsData GetCustomerOrderDetails(int customerId, string user);
        IList<ItemData> OrderItemDetails(int orderId);
    }
}
