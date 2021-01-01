using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersDirectoryMVC.Application.Interfaces;
using UsersDirectoryMVC.Application.ViewModels.AppUser;

namespace UsersDirectoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            var model = _appUserService.GetAllActiveAppUsersForList(3, 1, "");
            return Ok();
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
            var model = _appUserService.GetAllActiveAppUsersForList(pageSize, pageNumber.Value, searchString);
            return Ok();
        }

        [HttpGet("addAppUser")]
        public ActionResult<NewAppUserVm> AddAppUser()
        {
            var model = _appUserService.PrepareNewAppUserVm();

            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAppUser(NewAppUserVm appUser)
        {
            var id = _appUserService.AddAppUser(appUser);
            return RedirectToAction("Index");
        }

        [HttpGet("editappuser/{id}")]
        public ActionResult<NewAppUserVm> Get(int id)
        {
            var appUser = _appUserService.GetAppUserForEdit(id);

            if (appUser == null)
            {
                return NotFound();
            }
            return Ok(appUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditAppUser(NewAppUserVm model)
        {
            _appUserService.UpdateAppUser(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteAppUser(int id)
        {
            _appUserService.DeleteAppUser(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ViewAppUser(int id)
        {
            var appUserModel = _appUserService.GetAppUserDetails(id);
            return Ok();
        }
    }
}
