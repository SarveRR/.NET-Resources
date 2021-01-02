using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersDirectoryMVC.Application.Interfaces;
using UsersDirectoryMVC.Application.ViewModels;
using UsersDirectoryMVC.Application.ViewModels.Customer;

namespace UsersDirectoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [AllowAnonymous]
        [HttpGet("Index")]
        public ActionResult<ListCustomerForListVm> Index()
        {
            var model = _customerService.GetAllActiveCustomersForList(3, 1, "");
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }
        [AllowAnonymous]
        [HttpPost("Index")]
        public ActionResult<ListCustomerForListVm> Index([FromBody] SearchInListVm searchVm)
        {
            var pageNumber = searchVm.pageNumber;
            var searchString = searchVm.searchString;

            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            if (searchString is null)
            {
                searchString = String.Empty;
            }

            var model = _customerService.GetAllActiveCustomersForList(searchVm.pageSize, pageNumber, searchString);

            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpGet("AddCustomer")]
        public ActionResult<NewCustomerVm> AddCustomer()
        {
            var model = new NewCustomerVm();
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost("AddCustomer")]
        public ActionResult AddCustomer(NewCustomerVm model)
        {
            var id = _customerService.AddCustomer(model);
            return Ok(RedirectToAction("Index"));
        }

        [HttpGet("EditCustomer/{id}")]
        public ActionResult<NewCustomerVm> EditCustomer(int id)
        {
            var model = _customerService.GetCustomerForEdit(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost("EditCustomer")]
        public ActionResult EditCustomer(NewCustomerVm model)
        {
            _customerService.UpdateCustomer(model);
            return Ok(RedirectToAction("Index"));
        }

        [HttpGet("DeleteCustomer/{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            _customerService.DeleteCustomer(id);
            return Ok(RedirectToAction("Index"));
        }

        [HttpGet("ViewCustomer/{id}")]
        public ActionResult<CustomerDetailsVm> ViewCustomer(int id)
        {
            var model = _customerService.GetCustomerDetails(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }
    }
}
