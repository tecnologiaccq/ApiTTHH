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
    
    public partial class vBaseDatosContabilidadCompleta
    {
        public Nullable<long> Id { get; set; }
        public string Institución { get; set; }
        public string Grupo_de_comprobantes { get; set; }
        public Nullable<long> Número_de_comprobante { get; set; }
        public string Período_contable { get; set; }
        public Nullable<System.DateTime> Fecha_del_comprobante { get; set; }
        public string Beneficiario { get; set; }
        public string Identificación_beneficiario { get; set; }
        public string Concepto { get; set; }
        public string Número_de_cuenta { get; set; }
        public string Descripción_cuenta { get; set; }
        public decimal Débito { get; set; }
        public decimal Crédito { get; set; }
        public string Centro_de_costo { get; set; }
        public string Objeto_de_consumo { get; set; }
        public string Empleado { get; set; }
    }
}