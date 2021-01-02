using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersDirectoryMVC.Application.Interfaces;
using UsersDirectoryMVC.Application.ViewModels;
using UsersDirectoryMVC.Application.ViewModels.Assignment;

namespace UsersDirectoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [AllowAnonymous]
        [HttpGet("Index")]
        public ActionResult<ListAssignmentForListVm> Index()
        {
            var model = _assignmentService.GetAllActiveAssignmentsForList(3, 1, "");
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [AllowAnonymous]
        [HttpPost("Index")]
        public ActionResult<ListAssignmentForListVm> Index([FromBody] SearchInListVm searchVm)
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

            var model = _assignmentService.GetAllActiveAssignmentsForList(searchVm.pageSize, pageNumber, searchString);

            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpGet("AddAssignment")]
        public ActionResult<NewAssignmentVm> AddAssignment()
        {
            var model = new NewAssignmentVm();
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost("AddAssignment")]
        public ActionResult AddAssignment([FromBody] NewAssignmentVm model)
        {
            var id = _assignmentService.AddAssignment(model);
            return RedirectToAction("Index");
        }

        [HttpGet("EditAssignment/{id}")]
        public ActionResult<NewAssignmentVm> EditAssignment(int id)
        {
            var model = _assignmentService.GetAssignmentForEdit(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost("EditAssignment")]
        public ActionResult EditAssignment([FromBody] NewAssignmentVm model)
        {
            _assignmentService.UpdateAssignment(model);
            return RedirectToAction("Index");
        }

        [HttpGet("DeleteAssignment/{id}")]
        public ActionResult DeleteAssignment(int id)
        {
            _assignmentService.DeleteAssignment(id);
            return RedirectToAction("Index");
        }

        [HttpGet("ViewAssignment/{id}")]
        public ActionResult<AssignmentDetailsVm> ViewAssignment(int id)
        {
            var model = _assignmentService.GetAssignmentDetails(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }
    }
}
