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
    
    public partial class tGS_ServiciosClientes
    {
        public int IdServicioCliente { get; set; }
        public int IdServicio { get; set; }
        public int IdCliente { get; set; }
        public bool Estado { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        public virtual tCC_Clientes tCC_Clientes { get; set; }
        public virtual tGS_Servicios tGS_Servicios { get; set; }
    }
}
