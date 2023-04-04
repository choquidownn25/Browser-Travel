using Capa.Conexion.Modelos;
using Capa.ServiciosDistribuidos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Capa.Test.Api
{
    public class UnitTestLibros
    {
        private LibrosRepository librosRepository = new LibrosRepository();

        [Fact]
        public void TestGetAll()
        {
            //Arrange
            //Act
            var result = librosRepository.getAll().ToList();
            //Assert
            Assert.Equal(7, librosRepository.getAll().Count());

        }


        [Fact]
        public void TestGetByID()
        {
            //Arrange
            //Act
            var completeAutores = new Libros()
            {
                Id = 6,
                Ideditoriales = 6,
                Titulo = "Title",
                Sinopsis = "Title",
                NPaginas = "Description"
            };

            var result = librosRepository.getById(completeAutores.Id);
            //Assert
            Assert.Equal(6, result.Id);
        }

        [Fact]
        public void AddAutoresTest()
        {
            //OK RESULT TEST START

            //Arrange
            var completeLibros = new Libros()
            {
                Id = 6,
                Ideditoriales = 6,
                Titulo = "Title",
                Sinopsis = "Title",
                NPaginas = "Description"
            };

            // Act
            librosRepository.add(completeLibros);

        }

        [Fact]
        public void UpdateAutoresTest()
        {
            //OK RESULT TEST START

            //Arrange
            var completeLibros = new Libros()
            {
                Id = 6,
                Ideditoriales = 6,
                Titulo = "Title",
                Sinopsis = "Title",
                NPaginas = "Description"
            };

            // Act
            librosRepository.modify(completeLibros);


        }
    }
}
