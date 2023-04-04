using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using coderush.Models;
using Microsoft.AspNetCore.Authorization;
using Capa.Conexion.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capa.Repository.Repositorio;
using Prueba.Models;
using System;
using Prueba.Services;
using Prueba.Models.SyncfusionViewModels;
using Prueba.Data;

namespace Prueba.Controllers.Api
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Services")]
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INumberSequence _numberSequence;
        private readonly AsesoftwareContext asesoftware = new AsesoftwareContext();
        private readonly ServicesRepository servicesRepository = new ServicesRepository();
        public ServicesController(ApplicationDbContext context,
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
        public async Task<IActionResult> GetServices()
        {

            List<Capa.Conexion.Models.Services> Items = await asesoftware.Services.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }

        [HttpPost("[action]")]
        public IActionResult Insert([FromBody] CrudViewModel<ServicesModels> payload)
        {


            var model = new ServicesModels
            {
                IdComercio = payload.value.IdComercio,
                NomServicio = payload.value.NomServicio,
                HoraApertura = payload.value.HoraApertura,
                HoraCierre = payload.value.HoraCierre
            };
            //Services services  = payload.value;
            //_pruebaContext.TipoDocumento.Add(TipoDocumento);
            servicesRepository.add(model);
            //_pruebaContext.SaveChanges();
            return Ok(model);
        }

        [HttpPost("[action]")]
        public IActionResult Update([FromBody] CrudViewModel<ServicesModels> payload)
        {
            Capa.Conexion.Models.Services services = payload.value;
            //_pruebaContext.TipoDocumento.Update(tipoDocumento);
            servicesRepository.modify(services);
            //_pruebaContext.SaveChanges();
            return Ok(services);
        }

        [HttpPost("[action]")]
        public IActionResult Remove([FromBody] CrudViewModel<Capa.Conexion.Models.Services> payload)
        {
            Capa.Conexion.Models.Services services = payload.value;
            servicesRepository.delete(services.IdServicios);
            return Ok(services);

        }

    }
}
