using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Prueba.Pages;

namespace Prueba.Controllers
{
    [Authorize(Roles = MainMenu.Rol.RoleName)]
    public class RolController : Controller
    {
        private readonly IStringLocalizer<RolController> _localizer;

        public RolController(IStringLocalizer<RolController> localizer)
        {
            _localizer = localizer;
        }
        public IActionResult Index()

        {
            return View();
        }
    }
}