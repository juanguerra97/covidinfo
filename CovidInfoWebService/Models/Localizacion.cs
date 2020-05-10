using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidInfoWebService.Models
{

    /// <summary>
    /// Los objetos de esta clase almacenan los datos de Pais, Departamento y Municipio de cada caso de Covid 19 reportado
    /// </summary>
    public class Localizacion
    {

        public int LocalizacionId { get; set; }

        public string Pais { get; set; }

        public string Departamento { get; set; }

        public string Municipio { get; set; }

    }
}
