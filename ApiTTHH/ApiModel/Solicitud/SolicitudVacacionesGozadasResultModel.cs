using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ApiTTHH.ApiModel.Solicitud
{
    [DataContract]
    public class SolicitudVacacionesGozadasResultModel
    {
        [DataMember]
        public DateTime? FechaSolicitud { get; set; }

        [DataMember]
        public decimal? DiasSolicitados { get; set; }

        [DataMember]
        public DateTime? FechaInicio { get; set; }

        [DataMember]
        public DateTime? FechaFin { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Cargo { get; set; }

        [DataMember]
        public string NombreJefe { get; set; }

        [DataMember]
        public string NombreJefeTTHH { get; set; }

        [DataMember]
        public IEnumerable<DetalleSolicitudVacacionesGozadasResultModel> Detalle { get; set; }
    }
}