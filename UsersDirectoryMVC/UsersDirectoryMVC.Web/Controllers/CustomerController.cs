using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UsersDirectoryMVC.Web.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            var model = customerService.GetAllCustomersForList();
            return View();
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCustomer(CustomerModel model)
        {
            var id = customerService.AddCustomer(model);
            return View();
        }

        [HttpGet]
        public IActionResult AddNewAddressForClient(int customerId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewAddressForClient(AddressModel model)
        {
            return View();
        }

        public IActionResult ViewCustomer(int customerId)
        {
            var customerModel = customerService.GetCustomerDetails(customerId);
            return View(customerModel);
        }
    }
}
