//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiTTHH.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EV_Inscripcion
    {
        public int IdInscripcion { get; set; }
        public Nullable<int> IdEvento { get; set; }
        public Nullable<int> IdParticipante { get; set; }
        public Nullable<int> IdMedio { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public Nullable<int> cod_cupon { get; set; }
        public bool Asistio { get; set; }
        public string usuarioc { get; set; }
        public System.DateTime fechac { get; set; }
        public string estacionc { get; set; }
        public string usuarioa { get; set; }
        public System.DateTime fechaa { get; set; }
        public string estaciona { get; set; }
    
        public virtual EV_Evento EV_Evento { get; set; }
    }
}
