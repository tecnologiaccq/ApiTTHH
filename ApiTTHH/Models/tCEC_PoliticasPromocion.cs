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
    
    public partial class tCEC_PoliticasPromocion
    {
        public int ID { get; set; }
        public Nullable<int> IdProducto { get; set; }
        public Nullable<int> CantidadParticipantes { get; set; }
        public Nullable<int> idListaPrecio { get; set; }
        public Nullable<bool> AplicaSocio { get; set; }
        public Nullable<decimal> ValorFinal { get; set; }
    
        public virtual tFT_Productos tFT_Productos { get; set; }
    }
}