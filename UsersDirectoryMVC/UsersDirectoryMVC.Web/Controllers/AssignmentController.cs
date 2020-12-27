using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsersDirectoryMVC.Application.Interfaces;
using UsersDirectoryMVC.Application.ViewModels.Assignment;

namespace UsersDirectoryMVC.Web.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class AssignmentController : Controller
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _assignmentService.GetAllActiveAssignmentsForList(3, 1, "");
            return View(model);
        }
        [AllowAnonymous]
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
            var model = _assignmentService.GetAllActiveAssignmentsForList(pageSize, pageNumber.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddAssignment()
        {
            return View(new NewAssignmentVm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAssignment(NewAssignmentVm model)
        {
            var id = _assignmentService.AddAssignment(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditAssignment(int id)
        {
            var assignment = _assignmentService.GetAssignmentForEdit(id);
            return View(assignment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAssignment(NewAssignmentVm model)
        {
            _assignmentService.UpdateAssignment(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteAssignment(int id)
        {
            _assignmentService.DeleteAssignment(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ViewAssignment(int id)
        {
            var assignmentModel = _assignmentService.GetAssignmentDetails(id);
            return View(assignmentModel);
        }
    }
}

