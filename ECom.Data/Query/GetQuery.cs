using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Data.Query
{
    public static class GetQuery
    {
        public static string GETCUSTOMERDETAILS { get =>
                "SELECT C.FirstName, C.LastName, O.ORDERID AS OrderNumber, O.OrderDate,CONCAT(C.HOUSENO,', ',C.STREET,', ',C.TOWN,', ',C.POSTCODE) AS DeliveryAddress, O.DeliveryExpected, O.ContainsGift " +
                "FROM CUSTOMERS C WITH(NOLOCK) LEFT JOIN ORDERS O WITH(NOLOCK) ON O.CUSTOMERID = C.CUSTOMERID WHERE C.CUSTOMERID = 1 ORDER BY O.OrderDate DESC";
        }
        public static string GETITEMLIST
        {
            get => "SELECT P.PRODUCTNAME AS Product, O.QUANTITY AS Quantity, (O.PRICE/ O.QUANTITY) AS PriceEach" +
                "  FROM PRODUCTS P WITH(NOLOCK) INNER JOIN ORDERITEMS O WITH(NOLOCK) ON P.PRODUCTID = O.PRODUCTID WHERE O.ORDERID = @OrderId";
        }
        public static string GETEMAILIDBYCUSTOMERID
        {
            get => "SELECT TOP 1 EMAIL FROM CUSTOMERS WITH (NOLOCK) WHERE CUSTOMERID = @CustomerID";
        }
    }
}
