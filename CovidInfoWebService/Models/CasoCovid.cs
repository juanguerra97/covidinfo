using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidInfoWebService.Models
{

    /// <summary>
    /// Los objetos de esta clase almacenan los datos de los casos reportados de Covid 19.
    /// </summary>
    public class CasoCovid
    {

        public int CasoCovidId { get; set; }

        public string Pais { get; set; }

        public string Departamento { get; set; }

        public string Municipio { get; set; }

        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public byte Edad { get; set; }

        public char Sexo { get; set; }

        public DateTime Fecha { get; set; }


    }
}
