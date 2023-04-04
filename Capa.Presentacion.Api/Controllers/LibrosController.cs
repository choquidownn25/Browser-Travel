using Capa.Conexion.Modelos;
using Capa.ServiciosDistribuidos.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Capa.Presentacion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private LibrosRepository librosRepository = new LibrosRepository();
        /// <summary>
        /// Metodo para mostrar dastos en la tabla Alumno
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Libros> Get()
        {
            return librosRepository.getAll().ToArray();
        }
        [HttpGet("/{id}")]
        public Libros GetById(int id)
        {
            return librosRepository.getById(id);
        }
        [HttpPost]
        public IActionResult Add(Libros entity)
        {
            Libros Libros = entity;
            librosRepository.add(Libros);
            return Ok(Libros);
        }
        [HttpPut()]
        public IActionResult Update([FromBodyAttribute] Libros entity)
        {
            Libros Libros = entity;
            librosRepository.modify(Libros);
            return Ok(Libros);
        }
    }
}
