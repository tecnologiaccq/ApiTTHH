using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ApiTTHH.ModelClass
{
    [DataContract]
    public class EstadoCuentaColaboradorResultModel
    {
        [DataMember]
        public int? IdColaborador { get; set; }

        [DataMember]
        public int? IdTipoBeneficio { get; set; }

        [DataMember]
        public string TipoBeneficio { get; set; }

        [DataMember]
        public string IdTipoEstadpCuenta { get; set; }

        [DataMember]
        public decimal? Valor { get; set; }

        [DataMember]
        public string DescripcionEstado { get; set; }

        [DataMember]
        public DateTime? Fecha { get; set; }

        [DataMember]
        public decimal? SaldoCupo { get; set; }

        [DataMember]
        public decimal? SaldoGifcard { get; set; }

        [DataMember]
        public decimal? Total { get; set; }

        [DataMember]
        public int? MesesDiferir { get; set; }

        [DataMember]
        public int? IdReferencia { get; set; }

    }
}