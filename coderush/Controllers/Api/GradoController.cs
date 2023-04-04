using Capa.Conexion.Models;
using Capa.Repository.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba.Data;
using Prueba.Models;
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
    [Route("api/Grado")]
    public class GradoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INumberSequence _numberSequence;
        private readonly AsesoftwareContext asesoftware = new AsesoftwareContext();
        private GradoRepository gradoRepository = new GradoRepository();
        /// <summary>
        /// Adquiere permiso de la aplicacion
        /// </summary>
        /// <param name="context">Contexto del rol</param>
        /// <param name="numberSequence">Sequencia</param>
        public GradoController(ApplicationDbContext context,
                       INumberSequence numberSequence)
        {
            _context = context;
            _numberSequence = numberSequence;
        }
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Metodo para mostrar dastos en la tabla grado
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetGrado()
        {
            List<Grado> Items = await asesoftware.Grado.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }
        /// <summary>
        /// Metodo de Acccion Insertar
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult Insert([FromBody] CrudViewModel<GradoModels> payload)
        {


            Grado grado = payload.value;
            //_pruebaContext.TipoDocumento.Add(TipoDocumento);
            gradoRepository.add(grado);
            //_pruebaContext.SaveChanges();
            return Ok(grado);
        }
        /// <summary>
        /// Metodo de accion Actulizar
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult Update([FromBody] CrudViewModel<GradoModels> payload)
        {
            Grado grado = payload.value;
            //_pruebaContext.TipoDocumento.Update(tipoDocumento);
            gradoRepository.modify(grado);
            //_pruebaContext.SaveChanges();
            return Ok(grado);
        }
        /// <summary>
        /// Metodo de accion eliminar
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult Remove([FromBody] CrudViewModel<GradoModels> payload)
        {
            Grado grado = payload.value;
            gradoRepository.delete(grado.Id);
            return Ok(grado);

        }

    }
}
