using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsersDirectoryMVC.Application.Interfaces;

namespace UsersDirectoryMVC.Web.Controllers
{
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
        public IActionResult ManageRoles()
        {
            var model = _adminPanelService.GetAllUsers();
            return View(model);
        }

        [HttpPost]
        public IActionResult ManageRoles(int role)
        {
            var model = _adminPanelService.GetAllUsers();
            return View(model);
        }

        [HttpGet]
        public IActionResult ViewUser(string id)
        {
            var model = _adminPanelService.GetAllUsers();
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
