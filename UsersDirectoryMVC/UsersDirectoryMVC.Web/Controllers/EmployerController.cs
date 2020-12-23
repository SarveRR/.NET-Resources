using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsersDirectoryMVC.Application.Interfaces;
using UsersDirectoryMVC.Application.ViewModels.Employer;

namespace UsersDirectoryMVC.Web.Controllers
{
    public class EmployerController : Controller
    {
        private readonly IEmployerService _employerService;

        public EmployerController(IEmployerService employerService)
        {
            _employerService = employerService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _employerService.GetAllActiveEmployersForList(3, 1, "");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int pageSize, int? pageNumber, string searchString)
        {
            if (!pageNumber.HasValue)
            {
                pageNumber = 1;
            }
            if (searchString is null)
            {
                searchString = String.Empty;
            }
            var model = _employerService.GetAllActiveEmployersForList(pageSize, pageNumber.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddEmployer()
        {
            return View(new NewEmployerVm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmployer(NewEmployerVm model)
        {
            var id = _employerService.AddEmployer(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditEmployer(int id)
        {
            var employer = _employerService.GetEmployerForEdit(id);
            return View(employer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditEmployer(NewEmployerVm model)
        {
            _employerService.UpdateEmployer(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteEmployer(int id)
        {
            _employerService.DeleteEmployer(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ViewEmployer(int id)
        {
            var employerModel = _employerService.GetEmployerDetails(id);
            return View(employerModel);
        }
    }
}
