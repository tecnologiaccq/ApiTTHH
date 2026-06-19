using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiTTHH.Models.Custom.DTOs
{
    public class LoginResponseDto
    {
        public int IdColaborador { get; set; }
        public Nullable<int> IdPersona { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
        public Nullable<int> IdDepartamento { get; set; }
        public Nullable<int> IdTipoDiscapacidad { get; set; }
        public Nullable<decimal> PorcentajeDiscapacidad { get; set; }
        public Nullable<int> IdTipoColaborador { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public Nullable<int> IdEstado { get; set; }
        public Nullable<int> IdSupervisor { get; set; }
        public string Usuario { get; set; }
        public bool EsSupervisor { get; set; }
        public bool ApruebaTH { get; set; }
        public Nullable<bool> EsNominista { get; set; }
        public Nullable<bool> EsFinanciero { get; set; }
        public string Identificacion { get; set; }
        public string ApellidosNombres { get; set; }
        public string eMail { get; set; }
        public Nullable<bool> EnviarCorreoRolPago { get; set; }
        public string nickname { get; set; }
        public Nullable<int> IdTipoSangre { get; set; }
        public string UrlFoto { get; set; }
        public int CargasLEFAM { get; set; }
        public string NumeroTelefonoAuth2F { get; set; }
        public bool SegundoFactor { get; set; }
        public string ApellidosNombresSupervisor { get; set; }

    }
}