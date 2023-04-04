using Capa.Conexion.Models;
using Capa.Repository.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba.Data;
using Prueba.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Grafico")]
    public class GraficoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INumberSequence _numberSequence;
        private readonly AsesoftwareContext asesoftware = new AsesoftwareContext();
        private TurnoRepository turnoRepository = new TurnoRepository();
        public GraficoController(ApplicationDbContext context,
                        INumberSequence numberSequence)
        {
            _context = context;
            _numberSequence = numberSequence;
        }
        public IActionResult Index()
        {
            return View();
        }

        // GET: api/GoodsReceivedNote
        [HttpGet]
        public async Task<IActionResult> GetGrafico()
        {
            List<Grafico> Items = await asesoftware.Grafico.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }
    }
}
