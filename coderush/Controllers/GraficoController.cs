using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prueba.Models;
using System;
using System.Collections.Generic;
using Syncfusion.EJ2.Charts;
using Capa.Conexion.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Prueba.Pages;
using Prueba.Services;
using Prueba.Data;

namespace Prueba.Controllers
{
    [Authorize(Roles = MainMenu.Grafico.RoleName)]
    public class GraficoController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly INumberSequence _numberSequence;
        private readonly AsesoftwareContext asesoftware = new AsesoftwareContext();

        public GraficoController(ApplicationDbContext context,
                        INumberSequence numberSequence)
        {
            _context = context;
            _numberSequence = numberSequence;
        }
        public async Task<IActionResult> Index()
        {


            //List<Grafico> Items = await asesoftware.Grafico.ToListAsync();
            List<Grafico> graficos = await asesoftware.Grafico.ToListAsync();
            int Count = graficos.Count();
            return View(graficos);
        }

        // GET: api/GoodsReceivedNote
        [HttpGet]
        public async Task<IActionResult> GetGrafico()
        {

            var MobileSalesCounts = (from temp in asesoftware.Grafico
                                     select new { temp.Valor, temp.Anno }).ToArrayAsync();

            //List<Grafico> Items = await asesoftware.Grafico.ToListAsync();
            List<Grafico> graficos = await asesoftware.Grafico.ToListAsync();

            //list of department  
            List<GraficoModels> lstModel = new List<GraficoModels>();

            int Count = graficos.Count();
            return Ok(new { MobileSalesCounts });
        }


    }
}
