using CovidInfoWebService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidInfoUnitTests
{
    public static class CasosCovidData
    {

        public static List<CasoCovid> GetFakeCasos()
        {
            
            return new List<CasoCovid>
            {
                new CasoCovid {
                    Pais = "Guatemala",
                    Departamento = "Guatemala",
                    Municipio = "Villa Nueva",
                    Edad = 20,
                    Sexo = 'M',
                    Fecha = new DateTime(2020, 03, 14)
                },
                new CasoCovid {
                    Pais = "Guatemala",
                    Departamento = "Guatemala",
                    Municipio = "Villa Nueva",
                    Edad = 27,
                    Sexo = 'M',
                    Fecha = new DateTime(2020, 03, 17)
                },
                new CasoCovid {
                    Pais = "Guatemala",
                    Departamento = "Guatemala",
                    Municipio = "Guatemala",
                    Edad = 24,
                    Sexo = 'M',
                    Fecha = new DateTime(2020, 03, 17)
                },
                new CasoCovid {
                    Pais = "Guatemala",
                    Departamento = "Guatemala",
                    Municipio = "Guatemala",
                    Edad = 45,
                    Sexo = 'F',
                    Fecha = new DateTime(2020, 03, 18)
                },
                new CasoCovid {
                    Pais = "Guatemala",
                    Departamento = "San Marcos",
                    Municipio = "San Pedro",
                    Edad = 24,
                    Sexo = 'M',
                    Fecha = new DateTime(2020, 03, 17)
                },
                new CasoCovid {
                    Pais = "Guatemala",
                    Departamento = "Zacapa",
                    Municipio = "Zacapa",
                    Edad = 62,
                    Sexo = 'F',
                    Fecha = new DateTime(2020, 03, 19)
                },
                new CasoCovid {
                    Pais = "Guatemala",
                    Departamento = "Zacapa",
                    Municipio = "Estanzuela",
                    Edad = 31,
                    Sexo = 'M',
                    Fecha = new DateTime(2020, 03, 21)
                },
                new CasoCovid {
                    Pais = "Guatemala",
                    Departamento = "Quetzaltenango",
                    Municipio = "Olintepeque",
                    Edad = 42,
                    Sexo = 'M',
                    Fecha = new DateTime(2020, 03, 28)
                },
                new CasoCovid {
                    Pais = "Guatemala",
                    Departamento = "Quetzaltenango",
                    Municipio = "Quetzaltenango",
                    Edad = 23,
                    Sexo = 'F',
                    Fecha = new DateTime(2020, 03, 30)
                },
                new CasoCovid {
                    Pais = "Honduras",
                    Departamento = "Colón",
                    Municipio = "Trujillo",
                    Edad = 30,
                    Sexo = 'M',
                    Fecha = new DateTime(2020, 03, 18)
                },
                new CasoCovid {
                    Pais = "Honduras",
                    Departamento = "Choluteca",
                    Municipio = "Choluteca",
                    Edad = 47,
                    Sexo = 'F',
                    Fecha = new DateTime(2020, 03, 18)
                },
                new CasoCovid {
                    Pais = "México",
                    Departamento = "Coahuila",
                    Municipio = "Torreón",
                    Edad = 56,
                    Sexo = 'F',
                    Fecha = new DateTime(2020, 03, 7)
                }   
            };
        }

    }
}
