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
        [Fact]
        public async void GetCasosCovidPorPais()
        {

            using (var context = GetDbContext())
            {

                var controller = new ReporteCasoController(context);

                Assert.Equal(12, context.CasosCovid.AsEnumerable().Count());

                var result = (GetCasosCovidOkObjectResult)(await controller.GetCasosCovid(pais: "Guatemala")).Value;


                Assert.NotNull(result);

                Assert.Equal(9, result.Total);

                Assert.Equal(9, result.Registros.Count());

                Assert.NotNull(result.Filtro.Pais);
                Assert.Equal("Guatemala", result.Filtro.Pais);

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
        [Fact]
        public async void GetCasosCovidPorDepartamento()
        {

            using (var context = GetDbContext())
            {

                var controller = new ReporteCasoController(context);

                Assert.Equal(12, context.CasosCovid.AsEnumerable().Count());

                var result = (GetCasosCovidOkObjectResult)(await controller.GetCasosCovid(departamento: "Guatemala")).Value;


                Assert.NotNull(result);

                Assert.Equal(4, result.Total);

                Assert.Equal(4, result.Registros.Count());

                Assert.Null(result.Filtro.Pais);
                Assert.NotNull(result.Filtro.Departamento);
                Assert.Equal("Guatemala", result.Filtro.Departamento);
                Assert.Null(result.Filtro.Municipio);
                Assert.Null(result.Filtro.Edad);
                Assert.Null(result.Filtro.Sexo);
                Assert.Null(result.Filtro.Fecha);


            }

        }

        /// <summary>
        /// Se prueba que el metodo GetCasosCovid devuelva los registros correctos al filtrar por municipio
        /// </summary>
        [Fact]
        public async void GetCasosCovidPorMunicipio()
        {

            using (var context = GetDbContext())
            {

                var controller = new ReporteCasoController(context);

                Assert.Equal(12, context.CasosCovid.AsEnumerable().Count());

                var result = (GetCasosCovidOkObjectResult)(await controller.GetCasosCovid(municipio: "Villa Nueva")).Value;


                Assert.NotNull(result);

                Assert.Equal(2, result.Total);

                Assert.Equal(2, result.Registros.Count());

                Assert.Null(result.Filtro.Pais);
                Assert.Null(result.Filtro.Departamento);
                Assert.NotNull(result.Filtro.Municipio);
                Assert.Equal("Villa Nueva", result.Filtro.Municipio);
                Assert.Null(result.Filtro.Edad);
                Assert.Null(result.Filtro.Sexo);
                Assert.Null(result.Filtro.Fecha);


            }

        }

        /// <summary>
        /// Se prueba que el metodo GetCasosCovid devuelva los registros correctos al filtrar por edad
        /// </summary>
        [Fact]
        public async void GetCasosCovidPorEdad()
        {

            using (var context = GetDbContext())
            {

                var controller = new ReporteCasoController(context);

                Assert.Equal(12, context.CasosCovid.AsEnumerable().Count());

                var result = (GetCasosCovidOkObjectResult)(await controller.GetCasosCovid(edad: 24)).Value;


                Assert.NotNull(result);

                Assert.Equal(2, result.Total);

                Assert.Equal(2, result.Registros.Count());

                Assert.Null(result.Filtro.Pais);
                Assert.Null(result.Filtro.Departamento);
                Assert.Null(result.Filtro.Municipio);
                Assert.NotNull(result.Filtro.Edad);
                Assert.Equal((byte)24, result.Filtro.Edad);
                Assert.Null(result.Filtro.Sexo);
                Assert.Null(result.Filtro.Fecha);


            }

        }

        /// <summary>
        /// Se prueba que el metodo GetCasosCovid devuelva los registros correctos al filtrar por sexo
        /// </summary>
        [Fact]
        public async void GetCasosCovidPorSexo()
        {

            using (var context = GetDbContext())
            {

                var controller = new ReporteCasoController(context);

                Assert.Equal(12, context.CasosCovid.AsEnumerable().Count());

                var result = (GetCasosCovidOkObjectResult)(await controller.GetCasosCovid(sexo: 'M')).Value;


                Assert.NotNull(result);

                Assert.Equal(7, result.Total);

                Assert.Equal(7, result.Registros.Count());

                Assert.Null(result.Filtro.Pais);
                Assert.Null(result.Filtro.Departamento);
                Assert.Null(result.Filtro.Municipio);
                Assert.Null(result.Filtro.Edad);
                Assert.NotNull(result.Filtro.Sexo);
                Assert.Equal('M', result.Filtro.Sexo);
                Assert.Null(result.Filtro.Fecha);


            }

        }

        /// <summary>
        /// Se prueba que el metodo GetCasosCovid devuelva los registros correctos al filtrar por fecha
        /// </summary>
        [Fact]
        public async void GetCasosCovidPorFecha()
        {

            using (var context = GetDbContext())
            {

                var controller = new ReporteCasoController(context);

                Assert.Equal(12, context.CasosCovid.AsEnumerable().Count());

                var result = (GetCasosCovidOkObjectResult)(await controller.GetCasosCovid(fecha: new DateTime(2020, 03, 17))).Value;


                Assert.NotNull(result);

                Assert.Equal(3, result.Total);

                Assert.Equal(3, result.Registros.Count());

                Assert.Null(result.Filtro.Pais);
                Assert.Null(result.Filtro.Departamento);
                Assert.Null(result.Filtro.Municipio);
                Assert.Null(result.Filtro.Edad);
                Assert.Null(result.Filtro.Sexo);
                Assert.NotNull(result.Filtro.Fecha);
                Assert.Equal(new DateTime(2020, 03, 17), result.Filtro.Fecha);

            }

        }


        private static InfoCovidDbContext GetDbContext()
        {

            var builder = new DbContextOptionsBuilder<InfoCovidDbContext>();
            builder.UseInMemoryDatabase("covidinfo");
            var options = builder.Options;

            var context = new InfoCovidDbContext(options);

            context.AddRange(CasosCovidData.GetFakeCasos());
            context.SaveChanges();

            return context;

        }


    }

    

}
