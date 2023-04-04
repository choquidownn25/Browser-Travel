
using Capa.Conexion.Modelos;
using Capa.Domain.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Capa.ServiciosDistribuidos.Repositorios
{
    public class EditorialesRepositorios :  IBaseRepository<Editoriales> 
    {
        bookContext context = new bookContext();
        private TextReader reader;
        private bool disposed = false; //Para detectar llamadas redundantes
        public void add(Editoriales entity)
        {
            Editoriales entrada = new Editoriales
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Sede = entity.Sede

            };

            context.Editoriales.Add(entrada);
            context.SaveChanges();
        }

  

        public Editoriales getById(int id)
        {
            var consulta = (from r in context.Editoriales where r.Id == id select r).FirstOrDefault();
            return consulta;
        }

        public void modify(Editoriales entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
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

        public void delete(int id)
        {
            Editoriales editoriales = context.Editoriales.Find(id);
            context.Editoriales.Remove(editoriales);
            context.SaveChanges();
        }

        public IEnumerable<Editoriales> getAll()
        {
            try
            {
                List<Editoriales> lstObj = new List<Editoriales>();
                var result = (from item in context.Editoriales
                              select new
                              {
                                  item.Id,
                                  item.Nombre,
                                  item.Sede


                              }).ToList();

                foreach (var item in result)
                {
                    Editoriales item1 = new Editoriales();

                    item1.Id = item.Id;
                    item1.Nombre = item.Nombre;
                    item1.Sede = item.Sede;




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
    }
}
