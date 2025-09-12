using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTTHH.Models.Custom
{
    public class Cupo
    {
        public int idColaborador { get; set; }
        public int idTipobeneficio { get; set; }
        public decimal nuevocupo { get; set; }
        public decimal nuevaGifTCard { get; set; }
        public int mesesPlazo { get; set; }
        public Boolean  activaCumple  { get; set; }
        public string descripcion { get; set; }
    }
}