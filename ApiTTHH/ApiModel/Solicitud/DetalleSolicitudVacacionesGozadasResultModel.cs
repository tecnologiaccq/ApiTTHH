using System;
using System.Runtime.Serialization;

namespace ApiTTHH.ApiModel.Solicitud
{
    /// <summary>
    /// Clase Modelo Resultado Detalle Solicitud Vacaciones Gozadas
    /// </summary>
    [DataContract]
    public class DetalleSolicitudVacacionesGozadasResultModel
    {
        /// <summary>
        /// Días Período
        /// </summary>
        [DataMember]
        public decimal? DiasPeriodo { get; set; }

        /// <summary>
        /// Año
        /// </summary>
        [DataMember]
        public int? Anio { get; set; }

        /// <summary>
        /// Fecha Inicial
        /// </summary>
        [DataMember]
        public DateTime? FechaInicial { get; set;}

        /// <summary>
        /// Fecha Final
        /// </summary>
        [DataMember]
        public DateTime? FechaFinal { get; set; }
    }
}