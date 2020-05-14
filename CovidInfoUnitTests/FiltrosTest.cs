using CovidInfoWebService.Models;
using CovidInfoWebService.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
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
        [Theory]
        [InlineData(0, "Australia")]
        [InlineData(9, "Guatemala")]
        [InlineData(2, "Honduras")]
        [InlineData(1, "México")]
        [InlineData(0, "guatemala")]
        public void FiltroPorPais(int totalExpected, string pais)
        {

            Assert.Equal(totalExpected, CasosCovid.FiltrarPorPais(pais).Count());

        }

        /// <summary>
        /// Test para probar que el funcionamiento del método FiltrarPorDepartamento sea correcto
        /// </summary>
        [Theory]
        [InlineData(0, "Petén")]
        [InlineData(4, "Guatemala")]
        [InlineData(1, "San Marcos")]
        [InlineData(2, "Zacapa")]
        [InlineData(2, "Quetzaltenango")]
        [InlineData(0, "quetzaltenango")]
        public void FiltroPorDepartamento(int totalExpected, string departamento)
        {

            Assert.Equal(totalExpected, CasosCovid.FiltrarPorDepartamento(departamento).Count());

        }

        /// <summary>
        /// Test para probar que el funcionamiento del método FiltrarPorMunicipio sea correcto
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
        public void FiltroPorMunicipio(int totalExpected, string municipio)
        {

            Assert.Equal(totalExpected, CasosCovid.FiltrarPorMunicipio(municipio).Count());

        }

        /// <summary>
        /// Test para probar que el funcionamiento del método FiltrarPorEdad sea correcto
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
        public void FiltroPorEdad(int totalExpected, byte edad)
        {

            Assert.Equal(totalExpected, CasosCovid.FiltrarPorEdad(edad).Count());

        }

        /// <summary>
        /// Test para probar que el funcionamiento del método FiltrarPorSexo sea correcto
        /// </summary>
        [Theory]
        [InlineData(7, 'M')]
        [InlineData(5, 'F')]
        public void FiltroPorSexo(int totalExpected, char sexo)
        {

            Assert.Equal(totalExpected, CasosCovid.FiltrarPorSexo(sexo).Count());

        }

        /// <summary>
        /// Test para probar que el funcionamiento del método FiltrarPorFecha sea correcto
        /// </summary>
        [Theory]
        [ClassData(typeof(FiltrarPorFechaData))]
        public void FiltroPorFecha(int totalExpected, DateTime fecha)
        {

            Assert.Equal(totalExpected, CasosCovid.FiltrarPorFecha(fecha).Count());

        }

    }

}
