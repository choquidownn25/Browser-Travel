using Capa.Conexion.Modelos;
using Capa.ServiciosDistribuidos.Repositorios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capa.Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private AutoreRepository autoreRepository = new AutoreRepository();
        //private AutoreRepository autoreRepository = new AutoreRepository();
        /// <summary>
        /// Metodo para mostrar dastos en la tabla Alumno
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public IEnumerable<Autores> Get()
        {
            return autoreRepository.getAll().ToArray();
        }

       
        [HttpGet("/{id}")]
        public Autores GetById(int id)
        {
            return autoreRepository.FindById(id);
        }
        [HttpPost]
        public IActionResult Add(Autores entity)
        {
            Autores autores = entity;
            autoreRepository.add(autores);
            return Ok(autores);
        }
        [HttpPut()]
        public IActionResult Update([FromBodyAttribute] Autores entity)
        {
            Autores autores = entity;
            autoreRepository.modify(autores);
            return Ok(autores);
        }
    }

    
}
