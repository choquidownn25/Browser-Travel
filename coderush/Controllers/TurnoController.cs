using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Prueba.Controllers
{
    [Authorize(Roles = Pages.MainMenu.Turno.RoleName)]
    public class TurnoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
