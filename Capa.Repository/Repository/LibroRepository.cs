using Capa.Conexion.Modelos;
using Capa.Domain.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa.ServiciosDistribuidos.Repositorios
{
    public class LibrosRepository : IBaseRepository<Libros>
    {
        bookContext context = new bookContext();
        private TextReader reader;
        private bool disposed = false; //Para detectar llamadas redundantes
        public void add(Libros entity)
        {
            Libros entrada = new Libros
            {
                Id = entity.Id,
                Ideditoriales = entity.Ideditoriales,
                Titulo = entity.Titulo,
                Sinopsis = entity.Sinopsis,
                NPaginas = entity.NPaginas
            };

            context.Libros.Add(entrada);
            context.SaveChanges();
        }

        public IEnumerable<Libros> getAll()
        {
            try
            {
                List<Libros> lstObj = new List<Libros>();
                var result = (from item in context.Libros
                              select new
                              {
                                  item.Id,
                                  item.Ideditoriales,
                                  item.Titulo,
                                  item.Sinopsis,
                                  item.NPaginas
                              }).ToList();

                foreach (var item in result)
                {
                    Libros item1 = new Libros();

                    item1.Id = item.Id;
                    item1.Ideditoriales = item.Ideditoriales;
                    item1.Titulo = item.Titulo;
                    item1.Sinopsis = item.Sinopsis;
                    item1.NPaginas = item.NPaginas;
                    lstObj.Add(item1);
                }

                return lstObj;
            }

            catch (Exception e)
            {
                throw new Exception(
               "Entity Validation Failed - errors follow:\n" +
               e.ToString(), e
               );

            }
        }
        /// <summary>
        /// Metedo liberacion Memoria
        /// </summary>
        public void Dispose()
        {
            // Elimine los recursos no administrados.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// finalizacion del evento
        /// </summary>
        /// <param name="disposing">Entra inicial booleano</param>
        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (reader != null)
                    {
                        reader.Dispose();
                    }
                }

                disposed = true;
            }
        }
       

        public Libros getById(int id)
        {
            var consulta = (from r in context.Libros where r.Id == id select r).FirstOrDefault();
            return consulta;
        }

        public void modify(Libros entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void delete(int id)
        {
            Libros libros = context.Libros.Find(id);
            context.Libros.Remove(libros);
            context.SaveChanges();
        }
    }
}
