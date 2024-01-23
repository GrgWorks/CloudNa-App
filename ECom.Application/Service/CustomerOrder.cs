using ECom.Application.Contracts;
using ECom.Application.Models;
using ECom.Application.Models.Customer;
using ECom.Application.Models.Item;
using ECom.Application.Models.Order;
using ECom.Data.Contracts;
using ECom.Data.Models;
using ECom.Data.Models.CustomerData;
using ECom.Data.Models.ItemData;
using ECom.Data.Models.OrderData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Service
{
    public class CustomerOrder : ICustomerOrder
    {
        #region PVT PROPERTIES
        private readonly ICustomerOrdersRepo _customerOrdersRepo;
        private readonly ICustomerRepo _customerRepo;
        #endregion

        #region CONSTRUCTOR
        public CustomerOrder(ICustomerOrdersRepo customerOrdersRepo, 
            ICustomerRepo customerRepo)
        {
            _customerOrdersRepo = customerOrdersRepo;
            _customerRepo = customerRepo;
        }
        #endregion

        public CustomerOrderDetails GetCustomerOrderDetails(int cusotmerId, string Email)
        {
            if(!ValidateCustomer(cusotmerId, Email))
                return new CustomerOrderDetails() { };
            var customerDetails = _customerOrdersRepo.GetCustomerOrderDetails(cusotmerId, Email);
            var itemList = _customerOrdersRepo.OrderItemDetails(customerDetails.OrderNumber);
            return MapCustomerOrderDetails(customerDetails,itemList);
        }
        

        #region PVT METHODS
        private CustomerOrderDetails MapCustomerOrderDetails(CustomerOrderDetailsData customerOrderDetailsData, IList<ItemData> itemList)
        {
            return new CustomerOrderDetails()
            {
                Customer = MapCustomerDetails(customerOrderDetailsData),
                Order =  MapOrderDetails(customerOrderDetailsData, itemList)
            };
        }
        private Customer MapCustomerDetails(CustomerOrderDetailsData customerData)
        {
            return new Customer()
            {
                FirstName = customerData.FirstName,
                LastName = customerData.LastName
            };
        }
        private Order MapOrderDetails(CustomerOrderDetailsData customerOrderDetailsData, IList<ItemData> itemList)
        {
            if (customerOrderDetailsData.OrderNumber <= 0)
                return new Order() { };
            else
                return new Order()
                {
                    OrderDate = customerOrderDetailsData.OrderDate,
                    DeliveryAdress = customerOrderDetailsData.DeliveryAddress,
                    OrderNumber = customerOrderDetailsData.OrderNumber,
                    DeliveryExpected = customerOrderDetailsData.DeliveryExpected,
                    OrderItems = itemList.Select(x => MapOrderItems(x, customerOrderDetailsData.ContainsGift)).ToList()
                };
        }
        private Item MapOrderItems(ItemData item, bool isGift)
        {
            return new Item()
            {
                PriceEach = item.PriceEach,
                Product = isGift ? "GIFT" : item.Product,
                Quantity = item.Quantity

            };
        }
        private bool ValidateCustomer(int customerId, string email)
        {
            return _customerRepo.GetEmailIdByCustomerId(customerId) == email;
        }
        #endregion
    }
}
