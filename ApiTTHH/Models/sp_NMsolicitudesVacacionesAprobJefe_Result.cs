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
    
    public partial class sp_NMsolicitudesVacacionesAprobJefe_Result
    {
        public int IdSolicitudVacaciones { get; set; }
        public int IdColaborador { get; set; }
        public string Nickname { get; set; }
        public string ApellidosNombres { get; set; }
        public decimal diasSolicitados { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaFin { get; set; }
        public int IdEstadoAprob { get; set; }
        public string mesini { get; set; }
        public int diaini { get; set; }
        public string mesfin { get; set; }
        public int diafin { get; set; }
        public string Descripcion { get; set; }
        public int Anio { get; set; }
        public int IdColaboradorReemplazo { get; set; }
        public string Reemplazo { get; set; }
        public int IdTipoAusencia { get; set; }
    }
}
