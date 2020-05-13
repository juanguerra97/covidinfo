using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CovidInfoWebService.Models
{

    /// <summary>
    /// Los objetos de esta clase almacenan los datos de los casos reportados de Covid 19.
    /// </summary>
    public class CasoCovid
    {

        public int? CasoCovidId { get; set; }

        [Required(ErrorMessage = "Falta el pais")]
        [MaxLength(128, ErrorMessage = "La longitud maxima de {0} es {1}")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "Falta el departamento")]
        [MaxLength(128, ErrorMessage = "La longitud maxima de {0} es {1}")]
        public string Departamento { get; set; }

        [Required(ErrorMessage = "Falta el municipio")]
        [MaxLength(128, ErrorMessage = "La longitud maxima de {0} es {1}")]
        public string Municipio { get; set; }

        [Required(ErrorMessage = "Falta el primer nombre")]
        [MaxLength(64, ErrorMessage = "La longitud maxima de {0} es {1}")]
        public string PrimerNombre { get; set; }

        [MaxLength(64, ErrorMessage = "La longitud maxima de {0} es {1}")]
        public string SegundoNombre { get; set; }

        [Required(ErrorMessage = "Falta el primer apellido")]
        [MaxLength(64, ErrorMessage = "La longitud maxima de {0} es {1}")]
        public string PrimerApellido { get; set; }

        [MaxLength(64, ErrorMessage = "La longitud maxima de {0} es {1}")]
        public string SegundoApellido { get; set; }

        [Required(ErrorMessage = "Falta la edad")]
        [Range(1, 120, ErrorMessage = "La edad debe estar entre {1} y {2}")]
        public byte Edad { get; set; }

        [Sexo(ErrorMessage = "El sexo debe ser M (Masculino) o F (Femenino)")]
        [Required(ErrorMessage = "Falta el sexo")]
        public char Sexo { get; set; }

        [Required(ErrorMessage = "Falta la fecha")]
        public DateTime Fecha { get; set; }


    }

    public class SexoAttribute : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            var valorSexo = (char)value;

            return valorSexo == 'M' || valorSexo == 'F';
        }
    }


}
