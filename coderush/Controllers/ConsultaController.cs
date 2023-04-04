using Capa.Conexion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba.Data;
using Prueba.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INumberSequence _numberSequence;
        private readonly AsesoftwareContext asesoftware = new AsesoftwareContext();

        public ConsultaController(ApplicationDbContext context,
                        INumberSequence numberSequence)
        {
            _context = context;
            _numberSequence = numberSequence;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CunsultaNumero(int id)
        {
            ViewData["Id"] = new SelectList(asesoftware.IdentificaticionType, "Id", "Nombre");




            var consulta = await (from temp in asesoftware.Costumer
                                  where temp.Id == id
                                  orderby temp.Id
                                  select new 
                                  { 
                                      temp.Id,
                                      temp.Numero,
                                      temp.PrimerNombre,
                                      temp.SegundoNombre,
                                      temp.Email,
                                      temp.Direccion,
                                      temp.Celular,
                                      temp.IdType
                                  }).ToListAsync();
            if (consulta != null)
                return View(consulta);
            else
                return RedirectToAction("Home/Error");
        }

    }
}
