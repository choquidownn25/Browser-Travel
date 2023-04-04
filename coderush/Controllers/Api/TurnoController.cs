using Capa.Conexion.Models;
using Capa.Repository.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba.Data;
using Prueba.Models.SyncfusionViewModels;
using Prueba.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Turno")]
    public class TurnoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INumberSequence _numberSequence;
        private readonly AsesoftwareContext asesoftware = new AsesoftwareContext();
        private TurnoRepository turnoRepository = new TurnoRepository();
        public TurnoController(ApplicationDbContext context,
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
        public async Task<IActionResult> GetTurno()
        {
            List<Turno> Items = await asesoftware.Turno.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }
        [HttpPost("[action]")]
        public IActionResult Insert([FromBody] CrudViewModel<Turno> payload)
        {


            Turno turno = payload.value;
            //_pruebaContext.TipoDocumento.Add(TipoDocumento);
            turnoRepository.add(turno);
            //_pruebaContext.SaveChanges();
            return Ok(turno);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody] CrudViewModel<Turno> payload)
        {
            Turno turno = payload.value;
            //_pruebaContext.TipoDocumento.Update(tipoDocumento);
            turnoRepository.modify(turno);
            //_pruebaContext.SaveChanges();
            return Ok(turno);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody] CrudViewModel<Turno> payload)
        {
            Turno turno = payload.value;
            turnoRepository.delete(turno.IdTurno);
            return Ok(turno);

        }
    }
}
