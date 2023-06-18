using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTTHH.Models.Custom
{
    public class Pago
    {
        public int idCobro { get; set; }
        public int idColaborador { get; set; }
        public decimal total { get; set; }
        public decimal gifCard { get; set; }
        public decimal cupo { get; set; }
        public int mesesPlazo { get; set; }
        public decimal cuota { get; set; }
    }
}