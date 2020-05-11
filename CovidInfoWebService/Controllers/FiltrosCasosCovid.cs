
using System;
using System.Linq;
using CovidInfoWebService.Models;

namespace CovidInfoWebService.Utils
{
    public static class FiltrosCasosCovid
    {

        public static IQueryable<CasoCovid> FiltrarPorPais(this IQueryable<CasoCovid> casosCovid, string pais)
        {
            if (pais != null)
                return casosCovid.Where(c => c.Pais == pais);
            return casosCovid;
        }

        public static IQueryable<CasoCovid> FiltrarPorDepartamento(this IQueryable<CasoCovid> casosCovid, string departamento)
        {
            if (departamento != null)
                return casosCovid.Where(c => c.Departamento == departamento);
            return casosCovid;
        }

        public static IQueryable<CasoCovid> FiltrarPorMunicipio(this IQueryable<CasoCovid> casosCovid, string municipio)
        {
            if (municipio != null)
                return casosCovid.Where(c => c.Municipio == municipio);
            return casosCovid;
        }

        public static IQueryable<CasoCovid> FiltrarPorEdad(this IQueryable<CasoCovid> casosCovid, byte? edad)
        {
            if (edad != null)
                return casosCovid.Where(c => c.Edad == edad);
            return casosCovid;
        }

        public static IQueryable<CasoCovid> FiltrarPorSexo(this IQueryable<CasoCovid> casosCovid, char? sexo)
        {
            if (sexo != null)
                return casosCovid.Where(c => c.Sexo == sexo);
            return casosCovid;
        }

        public static IQueryable<CasoCovid> FiltrarPorFecha(this IQueryable<CasoCovid> casosCovid, DateTime? fecha)
        {
            if (fecha != null)
                return casosCovid.Where(c => c.Fecha.Equals(fecha));
            return casosCovid;
        }

    }
}
