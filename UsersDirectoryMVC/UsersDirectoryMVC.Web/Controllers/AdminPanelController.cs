using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UsersDirectoryMVC.Web.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public AdminPanelController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = _userManager.Users;

            return View(users);
        }
    }
}
