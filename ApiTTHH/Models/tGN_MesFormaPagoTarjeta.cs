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
    
    public partial class tGN_MesFormaPagoTarjeta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tGN_MesFormaPagoTarjeta()
        {
            this.tCC_CajaIngresoTarjetaCredito = new HashSet<tCC_CajaIngresoTarjetaCredito>();
            this.tCC_CajaIngresoTarjetaCreditoRelacionPagoTemp = new HashSet<tCC_CajaIngresoTarjetaCreditoRelacionPagoTemp>();
        }
    
        public int IdMesFormaPagoTarjeta { get; set; }
        public Nullable<int> IdFormaPagoTarjetaCredito { get; set; }
        public Nullable<int> CantidadMeses { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string EstacionCreacion { get; set; }
        public string ModificadoPor { get; set; }
        public Nullable<System.DateTime> UltimaModificacion { get; set; }
        public string EstacionModificacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CajaIngresoTarjetaCredito> tCC_CajaIngresoTarjetaCredito { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tCC_CajaIngresoTarjetaCreditoRelacionPagoTemp> tCC_CajaIngresoTarjetaCreditoRelacionPagoTemp { get; set; }
        public virtual tGN_FormaPagoTarjetaCredito tGN_FormaPagoTarjetaCredito { get; set; }
    }
}
