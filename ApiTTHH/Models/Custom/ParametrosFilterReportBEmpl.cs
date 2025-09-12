using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTTHH.Models.Custom
{
    public class ParametrosFilterReportBEmpl
    {
        public int idGenero { get; set; }
        public bool ? carnetDiscapacidad { get; set; }
        public bool ? movilizacion { get; set; }
        public int aniosExperienciaDesde { get; set; }
        public int aniosExperienciaHasta { get; set; }
        public decimal sueldoPretendidoDesde { get; set; }
        public decimal sueldoPretendidoHasta { get; set; }
        public int edadDesde { get; set; }
        public int edadHasta { get; set; }
        public string puesto { get; set; }
        public string estudio { get; set; }

    }
}