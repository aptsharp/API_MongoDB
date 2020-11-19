using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB.API.Models
{
    public class InfectadoDto
    {
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
