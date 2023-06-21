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
    
    public partial class tGN_Parametros
    {
        public int IdParametro { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public Nullable<decimal> CuotaMinimaAA { get; set; }
        public Nullable<decimal> CuotaMinimaAAA { get; set; }
        public string TipoImpuesto1 { get; set; }
        public string TipoImpuesto2 { get; set; }
        public string TipoImpuesto3 { get; set; }
        public string TipoImpuesto4 { get; set; }
        public string SMTPHost { get; set; }
        public string SMTPPort { get; set; }
        public Nullable<int> IdPeriodoUltimaGeneracionCuotas { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
        public Nullable<System.DateTime> UltimaDepreciacion { get; set; }
        public Nullable<int> IdTipoDocumentoCuotaOrdinaria { get; set; }
        public Nullable<int> IdConceptoCuotaOrdinaria { get; set; }
        public Nullable<int> IdTipoDocumentoCuotaExtraOrdinaria { get; set; }
        public Nullable<int> IdConceptoCuotaExtraOrdinaria { get; set; }
        public Nullable<int> NumeroCuotasSuspenso { get; set; }
        public Nullable<int> IdTipoDocumentoReversoCuotaSuspenso { get; set; }
        public Nullable<int> IdConceptoReversoCuotaSuspenso { get; set; }
    
        public virtual tGN_Empresas tGN_Empresas { get; set; }
    }
}