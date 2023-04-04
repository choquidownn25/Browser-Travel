using Capa.Conexion.Models;
using Capa.Repository.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Route("api/Comercios")]
    public class ComerciosController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly INumberSequence _numberSequence;
        private readonly AsesoftwareContext asesoftware = new AsesoftwareContext();
        private ComerciosRepository ComerciosRepository = new ComerciosRepository();
        public ComerciosController(ApplicationDbContext context,
                        INumberSequence numberSequence)
        {
            _context = context;
            _numberSequence = numberSequence;
        }
        // GET: ComerciosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: api/GoodsReceivedNote
        [HttpGet]
        public async Task<IActionResult> GetComercios()
        {
            List<Comercios> Items = await asesoftware.Comercios.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody] CrudViewModel<Comercios> payload)
        {
            Comercios Comercios = payload.value;
            //_pruebaContext.TipoDocumento.Add(TipoDocumento);
            ComerciosRepository.add(Comercios);
            //_pruebaContext.SaveChanges();
            return Ok(Comercios);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody] CrudViewModel<Comercios> payload)
        {
            Comercios Comercios = payload.value;
            //_pruebaContext.TipoDocumento.Update(tipoDocumento);
            ComerciosRepository.modify(Comercios);
            //_pruebaContext.SaveChanges();
            return Ok(Comercios);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody] CrudViewModel<Comercios> payload)
        {
            Comercios Comercios = payload.value;
            ComerciosRepository.delete(Comercios.IdComercio);
            return Ok(Comercios);

        }

    }
}
