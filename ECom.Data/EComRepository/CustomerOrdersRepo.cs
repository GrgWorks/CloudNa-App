using Dapper;
using ECom.Data.Contracts;
using ECom.Data.Models;
using ECom.Data.Models.ItemData;
using ECom.Data.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Data.EComRepository
{
    public class CustomerOrdersRepo : ICustomerOrdersRepo
    {
        #region CONSTANTS
        private const string SQLCONNECTIONSTRING = "Data Source=LAPTOP-KO3A4CE9\\SQLEXPRESS;Initial Catalog=first;Integrated Security=True;Encrypt=False";
        #endregion

        #region PUBLIC METHODS
        public CustomerOrderDetailsData GetCustomerOrderDetails(int customerId, string user)
        {
            var customers = new List<CustomerOrderDetailsData>();
            using (IDbConnection connection = new SqlConnection(SQLCONNECTIONSTRING))
            {
                var sql = GetQuery.GETCUSTOMERDETAILS;
                customers = connection.Query<CustomerOrderDetailsData>(sql, new { CustomerID = customerId }).ToList();
            }
            if (customers == null || customers.Count == 0)
            {
                return new CustomerOrderDetailsData();
            }
            else
                return customers.FirstOrDefault();
        }
        public IList<ItemData> OrderItemDetails(int orderId)
        {
            var itemList = new List<ItemData>();
            using (IDbConnection connection = new SqlConnection(SQLCONNECTIONSTRING))
            {
                var sql = GetQuery.GETITEMLIST;
                itemList = connection.Query<ItemData>(sql, new { OrderId = orderId }).ToList();

            }
            if (itemList.Count == 0)
            {
                return new List<ItemData>();
            }
            else
                return itemList;
        }
        #endregion
    }
}
