using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersDirectoryMVC.Application.Interfaces;
using UsersDirectoryMVC.Application.ViewModels;
using UsersDirectoryMVC.Application.ViewModels.AppUser;

namespace UsersDirectoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, User")]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [AllowAnonymous]
        [HttpGet("Index")]
        public ActionResult<ListAppUserForListVm> Index()
        {
            var model = _appUserService.GetAllActiveAppUsersForList(3, 1, "");
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [AllowAnonymous]
        [HttpPost("Index")]
        public ActionResult<ListAppUserForListVm> Index([FromBody] SearchInListVm searchVm)
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
            
            var model = _appUserService.GetAllActiveAppUsersForList(searchVm.pageSize, pageNumber, searchString);
            
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpGet("AddAppUser")]
        public ActionResult<NewAppUserVm> AddAppUser(int id)
        {
            var model = _appUserService.PrepareNewAppUserVm();

            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost("AddAppUser")]
        public ActionResult AddAppUser([FromBody] NewAppUserVm appUser)
        {
            var id = _appUserService.AddAppUser(appUser);
            return RedirectToAction("Index");
        }

        [HttpGet("EditAppUser/{id}")]
        public ActionResult<NewAppUserVm> EditAppUser(int id)
        {
            var appUser = _appUserService.GetAppUserForEdit(id);

            if (appUser == null)
            {
                return NotFound();
            }
            return Ok(appUser);
        }

        [HttpPost("EditAppUser")]
        public ActionResult EditAppUser([FromBody] NewAppUserVm model)
        {
            _appUserService.UpdateAppUser(model);
            return RedirectToAction("Index");
        }

        [HttpGet("DeleteAppUser/{id}")]
        public ActionResult DeleteAppUser(int id)
        {
            _appUserService.DeleteAppUser(id);
            return RedirectToAction("Index");
        }

        [HttpGet("ViewAppUser/{id}")]
        public ActionResult<AppUserDetailsVm> ViewAppUser(int id)
        {
            var model = _appUserService.GetAppUserDetails(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }
    }
}
