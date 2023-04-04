using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prueba.Pages;

namespace Prueba.Controllers
{
    [Authorize(Roles = MainMenu.Comercios.RoleName)]
    public class ComerciosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
