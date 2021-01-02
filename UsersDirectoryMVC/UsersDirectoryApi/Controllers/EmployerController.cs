using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersDirectoryMVC.Application.Interfaces;
using UsersDirectoryMVC.Application.ViewModels;
using UsersDirectoryMVC.Application.ViewModels.Employer;

namespace UsersDirectoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerService _employerService;

        public EmployerController(IEmployerService employerService)
        {
            _employerService = employerService;
        }
        [AllowAnonymous]
        [HttpGet("Index")]
        public ActionResult<ListEmployerForListVm> Index()
        {
            var model = _employerService.GetAllActiveEmployersForList(3, 1, "");
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [AllowAnonymous]
        [HttpPost("Index")]
        public ActionResult<ListEmployerForListVm> Index([FromBody] SearchInListVm searchVm)
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

            var model = _employerService.GetAllActiveEmployersForList(searchVm.pageSize, pageNumber, searchString);

            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpGet("AddEmployer")]
        public ActionResult<NewEmployerVm> AddEmployer()
        {
            var model = new NewEmployerVm();
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost("AddEmployer")]
        public ActionResult AddEmployer([FromBody] NewEmployerVm model)
        {
            var id = _employerService.AddEmployer(model);
            return RedirectToAction("Index");
        }

        [HttpGet("EditEmployer/{id}")]
        public ActionResult<NewEmployerVm> EditEmployer(int id)
        {
            var model = _employerService.GetEmployerForEdit(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost("EditEmployer")]
        public ActionResult EditEmployer([FromBody] NewEmployerVm model)
        {
            _employerService.UpdateEmployer(model);
            return RedirectToAction("Index");
        }

        [HttpGet("DeleteEmployer/{id}")]
        public ActionResult DeleteEmployer(int id)
        {
            _employerService.DeleteEmployer(id);
            return RedirectToAction("Index");
        }

        [HttpGet("ViewEmployer/{id}")]
        public ActionResult<EmployerDetailsVm> ViewEmployer(int id)
        {
            var model = _employerService.GetEmployerDetails(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }
    }
}
