using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsersDirectoryMVC.Application.Interfaces;
using UsersDirectoryMVC.Application.ViewModels.AppUser;

namespace UsersDirectoryMVC.Web.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class AppUserController : Controller
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
            var model = _appUserService.GetAllActiveAppUsersForList(pageSize, pageNumber.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddAppUser()
        {
            return View(new NewAppUserVm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAppUser(NewAppUserVm appUser)
        {
            var id = _appUserService.AddAppUser(appUser);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditAppUser(int id)
        {
            var appUser = _appUserService.GetAppUserForEdit(id);
            return View(appUser);
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
            return View(appUserModel);
        }
    }
}
