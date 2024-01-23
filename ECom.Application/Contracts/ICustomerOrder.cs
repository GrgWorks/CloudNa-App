using ECom.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Contracts
{
    public interface ICustomerOrder
    {
        CustomerOrderDetails GetCustomerOrderDetails(int cusotmerId, string Email);
    }
}
