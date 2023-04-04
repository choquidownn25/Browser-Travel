using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Prueba.Controllers
{
    [Authorize(Roles = Pages.MainMenu.Services.RoleName)]
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
