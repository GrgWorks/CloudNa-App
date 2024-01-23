using ECom.API.Models;
using ECom.Application.Contracts;
using ECom.Application.Service;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ECom.API.Controllers
{
    [ApiController]
    [Route("CustormerOrderDetails")]
    public class CustormerOrderDetailsController : ControllerBase
    {
        #region PRIVATE READONLY
        private readonly ILogger<CustormerOrderDetailsController> _logger;
        private readonly ICustomerOrder _customerOrder;
        #endregion

        #region CONSTRUCTOR
        public CustormerOrderDetailsController(ILogger<CustormerOrderDetailsController> logger, ICustomerOrder customerOrder)
        {
            _logger = logger;
            _customerOrder = customerOrder;
        }
        #endregion

        #region PUBLIC METHODS

        [HttpPost]
        public IActionResult GetCustormerOrderDetails(CustomerDetailsViewModel customerDetailsViewModel)
        {
            if(!ValidateModel(customerDetailsViewModel))
                return new ObjectResult("Invalid Input") { StatusCode = 400 };

            var result = _customerOrder.GetCustomerOrderDetails(customerDetailsViewModel.CustomerId, customerDetailsViewModel.User);
            if (result.Customer == null)
                return new ObjectResult("EmailId and CustomerId doesnot match") { StatusCode = 400 };
            else
                return Ok(result);
        }

        #endregion

        #region PVT METHODS
        private bool ValidateModel(CustomerDetailsViewModel customerDetailsViewModel)
        {
            if (customerDetailsViewModel.CustomerId <= 0 || customerDetailsViewModel.User == string.Empty)
            {
                return false;
            }
            else
                return true;
        }
        #endregion
    }
}
