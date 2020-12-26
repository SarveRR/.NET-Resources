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

        public IActionResult Index()
        {
            var model = _adminPanelService.GetAllUsers();
            return View(model);
        }
    }
}
