//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiTTHH.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ConfigTTHH
    {
        public int IdConfigTTHH { get; set; }
        public int IdCatTipoSolicitud { get; set; }
        public string Plantilla { get; set; }
        public string PathPlantilla { get; set; }
        public string PathArchivoPdf { get; set; }
        public string PathArchivoHtml { get; set; }
        public bool Estado { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public Nullable<System.DateTime> FechaEliminacion { get; set; }
    
        public virtual CatTipoSolicitud CatTipoSolicitud { get; set; }
    }
}