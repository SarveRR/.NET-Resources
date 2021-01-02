using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersDirectoryMVC.Application.Interfaces;
using UsersDirectoryMVC.Application.ViewModels.AdminPanel;

namespace UsersDirectoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminPanelController : ControllerBase
    {
        private readonly IAdminPanelService _adminPanelService;
        public AdminPanelController(IAdminPanelService adminPanelService)
        {
            _adminPanelService = adminPanelService;
        }

        [HttpGet("Index")]
        public ActionResult<ListUsersForListVm> Index()
        {
            var model = _adminPanelService.GetAllUsers();
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpGet("ManageRoles/{id}")]
        public ActionResult<UserDetailVm> ManageRoles(string id)
        {
            var model = _adminPanelService.GetUserRoles(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpPost("ManageRoles")]
        public async Task<ActionResult> ManageRoles(UserDetailVm user)
        {
            await _adminPanelService.ChangeUserRolesAsync(user.Id, user.UserRoles);
            return RedirectToAction("Index");
        }

        [HttpGet("ViewUser/{id}")]
        public ActionResult<UserDetailVm> ViewUser(string id)
        {
            var model = _adminPanelService.GetUserDetails(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpGet("DeleteUser/{id}")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            await _adminPanelService.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}
