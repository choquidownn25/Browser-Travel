using coderush.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prueba.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.Controllers
{
    [Authorize(Roles = MainMenu.Nota.RoleName)]
    public class NotaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
