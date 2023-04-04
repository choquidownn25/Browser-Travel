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
    public class EditorialeController : ControllerBase
    {
        private EditorialesRepositorios editorialesRepositorios = new EditorialesRepositorios();

        /// <summary>
        /// Metodo para mostrar dastos en la tabla Alumno
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Editoriales> Get()
        {
            return editorialesRepositorios.getAll().ToArray();
        }
        [HttpGet("/{id}")]
        public Editoriales GetById(int id)
        {
            return editorialesRepositorios.getById(id);
        }
        [HttpPost]
        public IActionResult Add(Editoriales entity)
        {
            Editoriales Editoriales = entity;
            editorialesRepositorios.add(Editoriales);
            return Ok(Editoriales);
        }
        [HttpPut()]
        public IActionResult Update([FromBodyAttribute] Editoriales entity)
        {
            Editoriales Editoriales = entity;
            editorialesRepositorios.modify(Editoriales);
            return Ok(Editoriales);
        }

    }
}
