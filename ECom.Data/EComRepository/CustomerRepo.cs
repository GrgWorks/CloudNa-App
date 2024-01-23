using ECom.Data.Contracts;
using ECom.Data.Models;
using ECom.Data.Query;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ECom.Data.EComRepository
{
    public class CustomerRepo : ICustomerRepo
    {
        #region CONSTANTS

        private const string SQLCONNECTIONSTRING = "Data Source=LAPTOP-KO3A4CE9\\SQLEXPRESS;Initial Catalog=first;Integrated Security=True;Encrypt=False";
        
        #endregion

        public string GetEmailIdByCustomerId(int customerId)
        {
            using (IDbConnection connection = new SqlConnection(SQLCONNECTIONSTRING))
            {
                var sql = GetQuery.GETEMAILIDBYCUSTOMERID;
                var emailId = connection.Query<string>(sql, new { CustomerID = customerId });
                return (emailId == null || emailId.Count() == 0) ? string.Empty : emailId.FirstOrDefault();
            }
        }

    }
}
