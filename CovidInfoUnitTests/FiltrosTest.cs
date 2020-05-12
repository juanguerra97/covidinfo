using CovidInfoWebService.Models;
using CovidInfoWebService.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CovidInfoUnitTests
{
    public class FiltrosTest
    {

        private IQueryable<CasoCovid> CasosCovid { get; } = GetData();

        [Fact]
        public void FiltroPorPais()
        {

            Assert.Equal(0, CasosCovid.FiltrarPorPais("Australia").Count());

            Assert.Equal(9, CasosCovid.FiltrarPorPais("Guatemala").Count());

            Assert.Equal(2, CasosCovid.FiltrarPorPais("Honduras").Count());

            Assert.Equal(1, CasosCovid.FiltrarPorPais("México").Count());

            Assert.Equal(0, CasosCovid.FiltrarPorPais("guatemala").Count());

            Assert.Equal(0, CasosCovid.FiltrarPorPais("Mexico").Count());

        }

        [Fact]
        public void FiltroPorDepartamento()
        {

            Assert.Equal(0, CasosCovid.FiltrarPorDepartamento("Petén").Count());

            Assert.Equal(4, CasosCovid.FiltrarPorDepartamento("Guatemala").Count());

            Assert.Equal(1, CasosCovid.FiltrarPorDepartamento("San Marcos").Count());

            Assert.Equal(2, CasosCovid.FiltrarPorDepartamento("Zacapa").Count());

            Assert.Equal(2, CasosCovid.FiltrarPorDepartamento("Quetzaltenango").Count());

            Assert.Equal(0, CasosCovid.FiltrarPorDepartamento("quetzaltenango").Count());

        }

        [Fact]
        public void FiltroPorMunicipio()
        {

            Assert.Equal(0, CasosCovid.FiltrarPorMunicipio("Tangamandapio").Count());

            Assert.Equal(2, CasosCovid.FiltrarPorMunicipio("Villa Nueva").Count());

            Assert.Equal(2, CasosCovid.FiltrarPorMunicipio("Guatemala").Count());

            Assert.Equal(1, CasosCovid.FiltrarPorMunicipio("Olintepeque").Count());

            Assert.Equal(1, CasosCovid.FiltrarPorMunicipio("San Pedro").Count());

            Assert.Equal(1, CasosCovid.FiltrarPorMunicipio("Zacapa").Count());

            Assert.Equal(1, CasosCovid.FiltrarPorMunicipio("Estanzuela").Count());

            Assert.Equal(1, CasosCovid.FiltrarPorMunicipio("Quetzaltenango").Count());

            Assert.Equal(0, CasosCovid.FiltrarPorMunicipio("quetzaltenango").Count());


        }

        [Fact]
        public void FiltroPorEdad()
        {

            Assert.Equal(0, CasosCovid.FiltrarPorEdad(100).Count());

            Assert.Equal(2, CasosCovid.FiltrarPorEdad(24).Count());

            Assert.Equal(1, CasosCovid.FiltrarPorEdad(20).Count());

            Assert.Equal(1, CasosCovid.FiltrarPorEdad(27).Count());

            Assert.Equal(1, CasosCovid.FiltrarPorEdad(45).Count());

            Assert.Equal(1, CasosCovid.FiltrarPorEdad(23).Count());

            Assert.Equal(1, CasosCovid.FiltrarPorEdad(42).Count());

            Assert.Equal(1, CasosCovid.FiltrarPorEdad(62).Count());

            Assert.Equal(1, CasosCovid.FiltrarPorEdad(31).Count());

        }

        [Fact]
        public void FiltroPorSexo()
        {

            Assert.Equal(6, CasosCovid.FiltrarPorSexo('M').Count());

            Assert.Equal(3, CasosCovid.FiltrarPorSexo('F').Count());

        }

        [Fact]
        public void FiltroPorFecha()
        {

            Assert.Equal(0, CasosCovid.FiltrarPorFecha(new DateTime(2020, 01, 01)).Count());

            Assert.Equal(1, CasosCovid.FiltrarPorFecha(new DateTime(2020, 03, 14)).Count());

            Assert.Equal(3, CasosCovid.FiltrarPorFecha(new DateTime(2020, 03, 17)).Count());

            Assert.Equal(1, CasosCovid.FiltrarPorFecha(new DateTime(2020, 03, 18)).Count());

            Assert.Equal(1, CasosCovid.FiltrarPorFecha(new DateTime(2020, 03, 19)).Count());

            Assert.Equal(1, CasosCovid.FiltrarPorFecha(new DateTime(2020, 03, 21)).Count());

            Assert.Equal(1, CasosCovid.FiltrarPorFecha(new DateTime(2020, 03, 28)).Count());

            Assert.Equal(1, CasosCovid.FiltrarPorFecha(new DateTime(2020, 03, 30)).Count());


        }

        private static IQueryable<CasoCovid> GetData()
        {
            var casos = new List<CasoCovid>();

            casos.Add(new CasoCovid
            {
                Pais = "Guatemala",
                Departamento = "Guatemala",
                Municipio = "Villa Nueva",
                Edad = 20,
                Sexo = 'M',
                Fecha = new DateTime(2020, 03, 14)
            });

            casos.Add(new CasoCovid
            {
                Pais = "Guatemala",
                Departamento = "Guatemala",
                Municipio = "Villa Nueva",
                Edad = 27,
                Sexo = 'M',
                Fecha = new DateTime(2020, 03, 17)
            });

            casos.Add(new CasoCovid
            {
                Pais = "Guatemala",
                Departamento = "Guatemala",
                Municipio = "Guatemala",
                Edad = 24,
                Sexo = 'M',
                Fecha = new DateTime(2020, 03, 17)
            });

            casos.Add(new CasoCovid
            {
                Pais = "Guatemala",
                Departamento = "Guatemala",
                Municipio = "Guatemala",
                Edad = 45,
                Sexo = 'F',
                Fecha = new DateTime(2020, 03, 18)
            });

            casos.Add(new CasoCovid
            {
                Pais = "Guatemala",
                Departamento = "San Marcos",
                Municipio = "San Pedro",
                Edad = 24,
                Sexo = 'M',
                Fecha = new DateTime(2020, 03, 17)
            });

            casos.Add(new CasoCovid
            {
                Pais = "Guatemala",
                Departamento = "Zacapa",
                Municipio = "Zacapa",
                Edad = 62,
                Sexo = 'F',
                Fecha = new DateTime(2020, 03, 19)
            });

            casos.Add(new CasoCovid
            {
                Pais = "Guatemala",
                Departamento = "Zacapa",
                Municipio = "Estanzuela",
                Edad = 31,
                Sexo = 'M',
                Fecha = new DateTime(2020, 03, 21)
            });

            casos.Add(new CasoCovid
            {
                Pais = "Guatemala",
                Departamento = "Quetzaltenango",
                Municipio = "Olintepeque",
                Edad = 42,
                Sexo = 'M',
                Fecha = new DateTime(2020, 03, 28)
            });

            casos.Add(new CasoCovid
            {
                Pais = "Guatemala",
                Departamento = "Quetzaltenango",
                Municipio = "Quetzaltenango",
                Edad = 23,
                Sexo = 'F',
                Fecha = new DateTime(2020, 03, 30)
            });

            casos.Add(new CasoCovid
            {
                Pais = "Honduras",
            });

            casos.Add(new CasoCovid
            {
                Pais = "Honduras",
            });

            casos.Add(new CasoCovid
            {
                Pais = "México",
            });

            return casos.AsQueryable();
        }

    }
}
