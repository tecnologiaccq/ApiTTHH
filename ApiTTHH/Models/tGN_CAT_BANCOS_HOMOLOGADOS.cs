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
    
    public partial class tGN_CAT_BANCOS_HOMOLOGADOS
    {
        public int IdHomologacion { get; set; }
        public Nullable<int> IdBancoCatalogoERP { get; set; }
        public string CodigoBancoDeAcuerdoCatalogoPropioDelBanco { get; set; }
        public Nullable<int> IdBancoCatalogoDestino { get; set; }
        public Nullable<int> CodigoBancoCatalogoDestino { get; set; }
        public string Nota1BancoDestino { get; set; }
        public string Nota2BancoDestino { get; set; }
    }
}
