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
    
    public partial class tCC_DescargosCabExtension
    {
        public int IdExtensionDescargo { get; set; }
        public int IdDescargoCab { get; set; }
        public Nullable<int> IdSocioReferencia { get; set; }
        public string RazonSocial { get; set; }
        public string Identificacion { get; set; }
        public Nullable<int> IdTipoIdentifcacion { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public Nullable<int> IdAsesor { get; set; }
        public Nullable<int> IdParroquia { get; set; }
        public string ReferenciaDireccion { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
    
        public virtual tGN_Empresas tGN_Empresas { get; set; }
    }
}
