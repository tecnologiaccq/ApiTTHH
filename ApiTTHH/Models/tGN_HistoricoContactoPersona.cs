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
    
    public partial class tGN_HistoricoContactoPersona
    {
        public int IdHistoricoContactoPersona { get; set; }
        public int IdContactoPersona { get; set; }
        public int IdCatEvento { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Info { get; set; }
        public string Ip { get; set; }
        public string ValorPrevio { get; set; }
        public string ValorNuevo { get; set; }
    
        public virtual CatEvento CatEvento { get; set; }
        public virtual tGN_ContactoPersona tGN_ContactoPersona { get; set; }
    }
}
