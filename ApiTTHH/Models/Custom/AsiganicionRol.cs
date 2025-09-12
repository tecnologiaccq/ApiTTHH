using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTTHH.Models.Custom
{
    public class AsiganicionRol
    {
        public string  Concepto { get; set; }
        public decimal ? Unidades { get; set; }
        public decimal  Asignacion { get; set; }
        public decimal  Deduccion { get; set; }
        public decimal  Saldo { get; set; }
    }
}