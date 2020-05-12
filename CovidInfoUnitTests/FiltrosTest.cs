using CovidInfoWebService.Models;
using CovidInfoWebService.Utils;
using System;
using System.Linq;
using Xunit;

namespace CovidInfoUnitTests
{
    public class FiltrosTest
    {

        private IQueryable<CasoCovid> CasosCovid { get; } = CasosCovidData.GetFakeCasos().AsQueryable();

        /// <summary>
        /// Test para probar que el funcionamiento del método FiltrarPorPais sea correcto
        /// </summary>
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

        /// <summary>
        /// Test para probar que el funcionamiento del método FiltrarPorDepartamento sea correcto
        /// </summary>
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

        /// <summary>
        /// Test para probar que el funcionamiento del método FiltrarPorMunicipio sea correcto
        /// </summary>
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

        /// <summary>
        /// Test para probar que el funcionamiento del método FiltrarPorEdad sea correcto
        /// </summary>
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

        /// <summary>
        /// Test para probar que el funcionamiento del método FiltrarPorSexo sea correcto
        /// </summary>
        [Fact]
        public void FiltroPorSexo()
        {

            Assert.Equal(7, CasosCovid.FiltrarPorSexo('M').Count());

            Assert.Equal(5, CasosCovid.FiltrarPorSexo('F').Count());

        }

        /// <summary>
        /// Test para probar que el funcionamiento del método FiltrarPorFecha sea correcto
        /// </summary>
        [Fact]
        public void FiltroPorFecha()
        {

            Assert.Equal(0, CasosCovid.FiltrarPorFecha(new DateTime(2020, 01, 01)).Count());

            Assert.Equal(1, CasosCovid.FiltrarPorFecha(new DateTime(2020, 03, 14)).Count());

            Assert.Equal(3, CasosCovid.FiltrarPorFecha(new DateTime(2020, 03, 17)).Count());

            Assert.Equal(3, CasosCovid.FiltrarPorFecha(new DateTime(2020, 03, 18)).Count());

            Assert.Equal(1, CasosCovid.FiltrarPorFecha(new DateTime(2020, 03, 19)).Count());

            Assert.Equal(1, CasosCovid.FiltrarPorFecha(new DateTime(2020, 03, 21)).Count());

            Assert.Equal(1, CasosCovid.FiltrarPorFecha(new DateTime(2020, 03, 28)).Count());

            Assert.Equal(1, CasosCovid.FiltrarPorFecha(new DateTime(2020, 03, 30)).Count());


        }

    }
}
