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
    [Route("api/Nota")]
    public class NotaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INumberSequence _numberSequence;
        private readonly AsesoftwareContext asesoftware = new AsesoftwareContext();
        private NotaRepository notaRepository = new NotaRepository();
        /// <summary>
        /// Adquiere permiso de la aplicacion
        /// </summary>
        /// <param name="context">Contexto del rol</param>
        /// <param name="numberSequence">Sequencia</param>
        public NotaController(ApplicationDbContext context,
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
        /// Metodo para mostrar dastos en la tabla Nota
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetNota()
        {
            List<Nota> Items = await asesoftware.Nota.ToListAsync();
            int Count = Items.Count();
            return Ok(new { Items, Count });
        }
        /// <summary>
        /// Metodo de Acccion Insertar
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult Insert([FromBody] CrudViewModel<NotaModels> payload)
        {


            Nota nota = payload.value;
            //_pruebaContext.TipoDocumento.Add(TipoDocumento);
            notaRepository.add(nota);
            //_pruebaContext.SaveChanges();
            return Ok(nota);
        }
        /// <summary>
        /// Metodo de accion Actulizar
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult Update([FromBody] CrudViewModel<NotaModels> payload)
        {
            Nota nota = payload.value;
            //_pruebaContext.TipoDocumento.Update(tipoDocumento);
            notaRepository.modify(nota);
            //_pruebaContext.SaveChanges();
            return Ok(nota);
        }
        /// <summary>
        /// Metodo de accion eliminar
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public IActionResult Remove([FromBody] CrudViewModel<NotaModels> payload)
        {
            Nota nota = payload.value;
            notaRepository.delete(nota.Id);
            return Ok(nota);

        }
    }
}
