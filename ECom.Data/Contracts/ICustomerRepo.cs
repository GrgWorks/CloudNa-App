using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Data.Contracts
{
    public interface ICustomerRepo
    {
        string GetEmailIdByCustomerId(int customerId);
    }
}
