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
    
    public partial class Adm_HistoryLoginDataManager
    {
        public int IdHistoryLoginDataManager { get; set; }
        public string Usuario { get; set; }
        public int IdCatEvento { get; set; }
        public System.DateTime FechaAcceso { get; set; }
        public string Info { get; set; }
        public string Ip { get; set; }
    
        public virtual CatEvento CatEvento { get; set; }
    }
}
