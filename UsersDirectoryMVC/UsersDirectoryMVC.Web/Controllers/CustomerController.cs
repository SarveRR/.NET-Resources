using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsersDirectoryMVC.Application.Interfaces;
using UsersDirectoryMVC.Application.ViewModels.Customer;

namespace UsersDirectoryMVC.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            var model = _customerService.GetAllActiveCustomersForList();
            return View(model);
        }

        //[HttpGet]
        //public IActionResult AddCustomer()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult AddCustomer(NewCustomerVm model)
        //{
        //    var id = _customerService.AddCustomer(model);
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult AddNewAddressForClient(int customerId)
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult AddNewAddressForClient(AddressForListVm model)
        //{
        //    return View();
        //}

        //public IActionResult ViewCustomer(int customerId)
        //{
        //    var customerModel = _customerService.GetCustomerDetails(customerId);
        //    return View(customerModel);
        //}
    }
}
