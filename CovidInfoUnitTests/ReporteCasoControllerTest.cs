using CovidInfoWebService.Controllers;
using CovidInfoWebService.DataAccess;
using CovidInfoWebService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CovidInfoUnitTests
{
    public class ReporteCasoControllerTest
    {

        /// <summary>
        /// Se prueba que el metodo GetCasosCovid devuelva todos los registros cuando no se le pasan argumentos
        /// </summary>
        [Fact]
        public async void GetAllCasosCovid()
        {
            using(var context = GetDbContext())
            {
                var controller = new ReporteCasoController(context);

                Assert.Equal(12, context.CasosCovid.AsEnumerable().Count());

                var result = (GetCasosCovidOkObjectResult)(await controller.GetCasosCovid()).Value;

                Assert.NotNull(result);

                Assert.Equal(12, result.Total);
                Assert.Equal(12, result.Registros.Count());

                Assert.Null(result.Filtro.Pais);
                Assert.Null(result.Filtro.Departamento);
                Assert.Null(result.Filtro.Municipio);
                Assert.Null(result.Filtro.Edad);
                Assert.Null(result.Filtro.Sexo);
                Assert.Null(result.Filtro.Fecha);
            }

        }

        /// <summary>
        /// Se prueba que el metodo GetCasosCovid devuelva los registros correctos al filtrar por pais
        /// </summary>
        [Theory]
        [InlineData(0, "Australia")]
        [InlineData(9, "Guatemala")]
        [InlineData(2, "Honduras")]
        [InlineData(1, "México")]
        [InlineData(0, "guatemala")]
        public async void GetCasosCovidPorPais(int totalExpected, string pais)
        {

            using (var context = GetDbContext())
            {

                var controller = new ReporteCasoController(context);

                Assert.Equal(12, context.CasosCovid.AsEnumerable().Count());

                var result = (GetCasosCovidOkObjectResult)(await controller.GetCasosCovid(pais: pais)).Value;


                Assert.NotNull(result);

                Assert.Equal(totalExpected, result.Total);
                Assert.Equal(totalExpected, result.Registros.Count());

                Assert.NotNull(result.Filtro.Pais);
                Assert.Equal(pais, result.Filtro.Pais);

                Assert.Null(result.Filtro.Departamento);
                Assert.Null(result.Filtro.Municipio);
                Assert.Null(result.Filtro.Edad);
                Assert.Null(result.Filtro.Sexo);
                Assert.Null(result.Filtro.Fecha);


            }

        }

        /// <summary>
        /// Se prueba que el metodo GetCasosCovid devuelva los registros correctos al filtrar por departamento
        /// </summary>
        [Theory]
        [InlineData(0, "Petén")]
        [InlineData(4, "Guatemala")]
        [InlineData(1, "San Marcos")]
        [InlineData(2, "Zacapa")]
        [InlineData(2, "Quetzaltenango")]
        [InlineData(0, "quetzaltenango")]
        public async void GetCasosCovidPorDepartamento(int totalExpected, string departamento)
        {
            using (var context = GetDbContext())
            {
                var controller = new ReporteCasoController(context);

                Assert.Equal(12, context.CasosCovid.AsEnumerable().Count());

                var result = (GetCasosCovidOkObjectResult)(await controller.GetCasosCovid(departamento: departamento)).Value;

                Assert.NotNull(result);

                Assert.Equal(totalExpected, result.Total);
                Assert.Equal(totalExpected, result.Registros.Count());

                Assert.Null(result.Filtro.Pais);

                Assert.NotNull(result.Filtro.Departamento);
                Assert.Equal(departamento, result.Filtro.Departamento);

                Assert.Null(result.Filtro.Municipio);
                Assert.Null(result.Filtro.Edad);
                Assert.Null(result.Filtro.Sexo);
                Assert.Null(result.Filtro.Fecha);


            }

        }

        /// <summary>
        /// Se prueba que el metodo GetCasosCovid devuelva los registros correctos al filtrar por municipio
        /// </summary>
        [Theory]
        [InlineData(0, "Tangamandapio")]
        [InlineData(2, "Villa Nueva")]
        [InlineData(2, "Guatemala")]
        [InlineData(1, "Olintepeque")]
        [InlineData(1, "San Pedro")]
        [InlineData(1, "Estanzuela")]
        [InlineData(1, "Zacapa")]
        [InlineData(1, "Quetzaltenango")]
        [InlineData(0, "quetzaltenango")]
        public async void GetCasosCovidPorMunicipio(int totalExpected, string municipio)
        {
            using (var context = GetDbContext())
            {
                var controller = new ReporteCasoController(context);

                Assert.Equal(12, context.CasosCovid.AsEnumerable().Count());

                var result = (GetCasosCovidOkObjectResult)(await controller.GetCasosCovid(municipio: municipio)).Value;

                Assert.NotNull(result);

                Assert.Equal(totalExpected, result.Total);
                Assert.Equal(totalExpected, result.Registros.Count());

                Assert.Null(result.Filtro.Pais);
                Assert.Null(result.Filtro.Departamento);

                Assert.NotNull(result.Filtro.Municipio);
                Assert.Equal(municipio, result.Filtro.Municipio);

                Assert.Null(result.Filtro.Edad);
                Assert.Null(result.Filtro.Sexo);
                Assert.Null(result.Filtro.Fecha);
            }

        }

        /// <summary>
        /// Se prueba que el metodo GetCasosCovid devuelva los registros correctos al filtrar por edad
        /// </summary>
        [Theory]
        [InlineData(0, 100)]
        [InlineData(2, 24)]
        [InlineData(1, 20)]
        [InlineData(1, 27)]
        [InlineData(1, 45)]
        [InlineData(1, 23)]
        [InlineData(1, 42)]
        [InlineData(1, 62)]
        [InlineData(1, 31)]
        public async void GetCasosCovidPorEdad(int totalExpected, byte edad)
        {
            using (var context = GetDbContext())
            {
                var controller = new ReporteCasoController(context);

                Assert.Equal(12, context.CasosCovid.AsEnumerable().Count());

                var result = (GetCasosCovidOkObjectResult)(await controller.GetCasosCovid(edad: edad)).Value;


                Assert.NotNull(result);

                Assert.Equal(totalExpected, result.Total);
                Assert.Equal(totalExpected, result.Registros.Count());

                Assert.Null(result.Filtro.Pais);
                Assert.Null(result.Filtro.Departamento);
                Assert.Null(result.Filtro.Municipio);

                Assert.NotNull(result.Filtro.Edad);
                Assert.Equal(edad, result.Filtro.Edad);
                
                Assert.Null(result.Filtro.Sexo);
                Assert.Null(result.Filtro.Fecha);
            }

        }

        /// <summary>
        /// Se prueba que el metodo GetCasosCovid devuelva los registros correctos al filtrar por sexo
        /// </summary>
        [Theory]
        [InlineData(7, 'M')]
        [InlineData(5, 'F')]
        public async void GetCasosCovidPorSexo(int totalExpected, char sexo)
        {
            using (var context = GetDbContext())
            {
                var controller = new ReporteCasoController(context);

                Assert.Equal(12, context.CasosCovid.AsEnumerable().Count());

                var result = (GetCasosCovidOkObjectResult)(await controller.GetCasosCovid(sexo: sexo)).Value;

                Assert.NotNull(result);

                Assert.Equal(totalExpected, result.Total);
                Assert.Equal(totalExpected, result.Registros.Count());

                Assert.Null(result.Filtro.Pais);
                Assert.Null(result.Filtro.Departamento);
                Assert.Null(result.Filtro.Municipio);
                Assert.Null(result.Filtro.Edad);

                Assert.NotNull(result.Filtro.Sexo);
                Assert.Equal(sexo, result.Filtro.Sexo);

                Assert.Null(result.Filtro.Fecha);
            }

        }

        /// <summary>
        /// Se prueba que el metodo GetCasosCovid devuelva los registros correctos al filtrar por fecha
        /// </summary>
        [Theory]
        [ClassData(typeof(FiltrarPorFechaData))]
        public async void GetCasosCovidPorFecha(int totalExpected, DateTime fecha)
        {

            using (var context = GetDbContext())
            { 
                var controller = new ReporteCasoController(context);

                Assert.Equal(12, context.CasosCovid.AsEnumerable().Count());

                var result = (GetCasosCovidOkObjectResult)(await controller.GetCasosCovid(fecha: fecha)).Value;


                Assert.NotNull(result);

                Assert.Equal(totalExpected, result.Total);
                Assert.Equal(totalExpected, result.Registros.Count());

                Assert.Null(result.Filtro.Pais);
                Assert.Null(result.Filtro.Departamento);
                Assert.Null(result.Filtro.Municipio);
                Assert.Null(result.Filtro.Edad);
                Assert.Null(result.Filtro.Sexo);

                Assert.NotNull(result.Filtro.Fecha);
                Assert.Equal(fecha, result.Filtro.Fecha);

            }

        }


        private static InfoCovidDbContext GetDbContext()
        {

            var builder = new DbContextOptionsBuilder<InfoCovidDbContext>();
            builder.UseInMemoryDatabase("covidinfo");
            var options = builder.Options;

            var context = new InfoCovidDbContext(options);

            if (context.CasosCovid.Count() == 0)
            {
                context.AddRange(CasosCovidData.GetFakeCasos());
                context.SaveChanges();
            }

            return context;

        }

    }

}
