using Capa.Conexion.Modelos;
using Capa.Domain.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Capa.ServiciosDistribuidos.Repositorios
{
    public class AutoreRepository : IBaseRepository<Autores>
    {
        bookContext context = new bookContext();
        private bool disposed = false; //Para detectar 
        private TextReader reader;

        public void add(Autores entity)
        {
            Autores entrada = new Autores
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Apellido = entity.Apellido

            };

            context.Autores.Add(entrada);
            context.SaveChanges();
        }
        public void delete(int id)
        {
            Autores autores = context.Autores.Find(id);
            context.Autores.Remove(autores);
            context.SaveChanges();
        }

        public void Dispose()
        {
            // Elimine los recursos no administrados.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

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

        public Autores FindById(int id)
        {
            var consulta = (from r in context.Autores where r.Id == id select r).FirstOrDefault();
            return consulta;
        }

        public IEnumerable<Autores> getAll()
        {
            try
            {
                List<Autores> lstObj = new List<Autores>();
                var result = (from item in context.Autores
                              select new
                              {
                                  item.Id,
                                  item.Nombre,
                                  item.Apellido


                              }).ToList();

                foreach (var item in result)
                {
                    Autores item1 = new Autores();

                    item1.Id = item.Id;
                    item1.Nombre = item.Nombre;
                    item1.Apellido = item.Apellido;




                    lstObj.Add(item1);
                }

                return lstObj;
            }
            catch (Exception e)
            {
                throw new Exception(
                "Entity Validation Failed - errors follow:\n" +
                e.ToString(), e
                ); // Add the original exception as the innerException

            }
        }
        public Autores getById(int id)
        {
            Autores autores = context.Autores
               .Where(x => x.Id == id)
               .FirstOrDefault();
            return autores;
        }

        public void modify(Autores entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
           
        }

       
    }
}
