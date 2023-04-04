using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Prueba.Models;
using Prueba.Pages;

namespace Prueba.Controllers
{

    public class UserRoleController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IStringLocalizer<ApplicationUser> _localizer;

        public UserRoleController(UserManager<ApplicationUser> userManager, IStringLocalizer<ApplicationUser> localizer)
        {
            _userManager = userManager;
            _localizer = localizer;
        }


        [Authorize(Roles = MainMenu.User.RoleName)]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = MainMenu.ChangePassword.RoleName)]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Authorize(Roles = MainMenu.Role.RoleName)]
        public IActionResult Role()
        {
            return View();
        }

        [Authorize(Roles = MainMenu.ChangeRole.RoleName)]
        public IActionResult ChangeRole()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> UserProfile()
        {
            ViewBag.TotalCreditos = 0;
            ApplicationUser user = await _userManager.GetUserAsync(User);


            return View(user);
        }
    }
}