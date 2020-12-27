using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsersDirectoryMVC.Application.Interfaces;
using UsersDirectoryMVC.Application.ViewModels.AdminPanel;

namespace UsersDirectoryMVC.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminPanelController : Controller
    {
        private readonly IAdminPanelService _adminPanelService;
        public AdminPanelController(IAdminPanelService adminPanelService)
        {
            _adminPanelService = adminPanelService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _adminPanelService.GetAllUsers();
            return View(model);
        }

        [HttpGet]
        public IActionResult ManageRoles(string id)
        {
            var model = _adminPanelService.GetUserRoles(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageRoles(UserDetailVm user)
        {
            await _adminPanelService.ChangeUserRolesAsync(user.Id, user.UserRoles);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ViewUser(string id)
        {
            var model = _adminPanelService.GetUserDetails(id);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _adminPanelService.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}
