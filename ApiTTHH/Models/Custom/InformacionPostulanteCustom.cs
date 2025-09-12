using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTTHH.Models.Custom
{
    public class InformacionPostulanteCustom
    {
        public int id { get; set; }
        public string correo { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public int tipoIdentificacion { get; set; }
        public string identificacion { get; set; }
        public int nacionalidad { get; set; }
        public int estadoCivil { get; set; }
        public int genero { get; set; }
        public int provincia { get; set; }
        public int ciudad { get; set; }
        public int idCapacitacion { get; set; }
        public string otroDescripcion { get; set; }
        public string celular { get; set; }
        public bool movilizacion { get; set; }
        public bool discapacidad { get; set; }
        public string tiposDiscapacidades { get; set; }
        public string fechaPost { get; set; }
        public decimal salario { get; set; }
    }
}