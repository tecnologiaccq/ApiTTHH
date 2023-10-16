using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using DevExpress.XtraEditors.Filtering.Templates;

namespace ApiTTHH.ModelClass
{
    [DataContract]
    public class ColaboradorResultModel
    {
        [DataMember] 
        public int? IdColaborador { get; set; }

        [DataMember]
        public int? IdPersona { get; set; }

        [DataMember]
        public int? IdDepartamento { get; set; }

        [DataMember]
        public int? IdTipoDiscapacidad { get; set; }

        [DataMember]
        public decimal? PorcentajeDiscapacidad { get; set; }

        [DataMember]
        public int? idTipoColaborador { get; set; }

        [DataMember]
        public int? IdClaseColaborador { get; set; }

        [DataMember]
        public int? IdCategoriaColaborador { get; set; }

        [DataMember]
        public int? IdGrupoColaborador { get; set; }

        [DataMember]
        public int? IdProgramaColaborador { get; set; }

        [DataMember]
        public int? IdTurno { get; set; }

        [DataMember]
        public DateTime? FechaIngreso { get; set; }

        [DataMember]
        public int? IdEstado { get; set; }

        [DataMember]
        public int? IdSupervisor { get; set; }

        [DataMember]
        public int? IdBanco { get; set; }

        [DataMember]
        public int? IdTipoCuenta { get; set; }

        [DataMember]
        public string NumeroCuenta { get; set; }

        [DataMember]
        public int? IdMedioPago { get; set; }

        [DataMember]
        public int? IdTipoContrato { get; set; }

        [DataMember]
        public string Usuario { get; set; }

        [DataMember]
        public int? IdCargo { get; set; }

        [DataMember]
        public bool? EsSupervisor { get; set; }

        [DataMember]
        public bool? ApruebaTH { get; set; }

        [DataMember]
        public bool? EsNominista {get; set; }

        [DataMember]
        public bool? EsFinanciero { get; set; }

        [DataMember]
        public string CreadoPor { get; set; }

        [DataMember]
        public DateTime? FechaCreacion { get; set; }

        [DataMember]
        public string EstacionCreacion { get; set; }

        [DataMember]
        public string ModificadoPor { get; set; }

        [DataMember]
        public DateTime? UltimaModificacion { get; set; }

        [DataMember]
        public string EstacionModificacion { get; set; }

        [DataMember]
        public string NumeroDiscapacitado { get; set; }

        [DataMember]
        public int? IdSucursal { get; set; }

        [DataMember]
        public int? IdSectorialIESS { get; set; }

        [DataMember]
        public int? IdTitulo { get; set; }

        [DataMember]
        public int? IdArea { get; set; }

        [DataMember]
        public int? IdMotivoEgreso { get; set; }

        [DataMember]
        public DateTime? FechaEgreso { get; set; }

        [DataMember]
        public bool? EsReelegible { get; set; }

        [DataMember]
        public int? IdCategoriaOcupacional { get; set; }

        [DataMember]
        public int? IdBiometrico {get; set; }

        [DataMember]
        public long? HoraEntrada { get; set; }

        [DataMember]
        public long? HoraSalida { get; set; }

        [DataMember]
        public long? TiempoAlmuerzo { get; set; }

        [DataMember]
        public int? IdCategoria1 { get; set; }

        [DataMember]
        public int? IdCategoria2 { get; set; }

        [DataMember]
        public int? IdCategoria3 { get; set; }

        [DataMember]
        public int? IdCategoria4 { get; set; }

        [DataMember]
        public int? IdCategoria5 { get; set; }

        [DataMember]
        public string Identificacion { get; set; }

        [DataMember]
        public string ApellidosNombres { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public decimal? HorasSemanalesJornadaParcial { get; set; }

        [DataMember]
        public DateTime? FechaJubilacion { get; set; }

        [DataMember]
        public bool? TieneBeneficioGalapagos { get; set; }

        [DataMember]
        public string CodigoEstablecimiento { get; set; }

        [DataMember]
        public bool? ResideEnElExterior { get; set; }

        [DataMember]
        public bool? TieneConvenioDobleImposicion { get; set; }

        [DataMember]
        public int? CondicionDiscapacidad { get; set; }

        [DataMember]
        public int? TipoIdDiscapacitado { get; set; }

        [DataMember]
        public string IdDiscapacitado { get; set; }

        [DataMember]
        public bool? TieneSalarioNeto { get; set; }

        [DataMember]
        public int? IdTipoRelacion { get; set; }

        [DataMember]
        public DateTime? FechaDefuncion { get; set; }

        [DataMember]
        public bool? EnviarCorreoRolPago {get; set; }

        [DataMember]
        public string Nickname { get; set; }

        [DataMember]
        public int? IdTipoSangre { get; set; }

        [DataMember]
        public string UrlFoto { get; set; }
    }
}