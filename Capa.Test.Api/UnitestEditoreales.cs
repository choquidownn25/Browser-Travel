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
    public class UnitestEditoreales
    {
        private EditorialesRepositorios editorialesRepositorios = new EditorialesRepositorios();

        [Fact]
        public void TestGetAll()
        {
            //Arrange
            //Act
            var result = editorialesRepositorios.getAll().ToList();
            //Assert
            Assert.Equal(7, editorialesRepositorios.getAll().Count());

        }


        [Fact]
        public void TestGetByID()
        {
            //Arrange
            //Act
            var completeEditoriales = new Editoriales()
            {
                Id = 6,
                Nombre = "Title",
                Sede = "Description"
            };

            var result = editorialesRepositorios.getById(completeEditoriales.Id);
            //Assert
            Assert.Equal(6, result.Id);
        }

        [Fact]
        public void AddAutoresTest()
        {
            //OK RESULT TEST START

            //Arrange
            var completeEditoriales = new Editoriales()
            {
                Id = 7,
                Nombre = "Title",
                Sede = "Description"
            };

            // Act
            editorialesRepositorios.add(completeEditoriales);

        }

        [Fact]
        public void UpdateAutoresTest()
        {
            //OK RESULT TEST START

            //Arrange
            var completeEditoriales = new Editoriales()
            {
                Id = 4,
                Nombre = "Titles",
                Sede = "Descriptions"
            };

            // Act
            editorialesRepositorios.modify(completeEditoriales);


        }
    }
}
