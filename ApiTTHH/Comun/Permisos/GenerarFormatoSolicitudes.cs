using System;
using System.Collections.Generic;
using System.Diagnostics;
using ApiTTHH.Reportes;
using DevExpress.DataAccess.Json;
using ApiTTHH.Utils;

namespace ApiTTHH.Comun.Permisos
{
    public static class GenerarFormatoSolicitudes
    {
        //public SubirArchivosAzure a = new SubirArchivosAzure();
        public static List<string> GeneraSolicitudFileVacaciones(string json, int idSolicitud, int idColaborador)
        {
            List<string> results = new List<string>();
            try
            {

                SolicitudVacacion reportSolicitud = new SolicitudVacacion();

                string path = System.Web.HttpContext.Current.Server.MapPath("~/api/pdf/SolicitudVacacion_") + idSolicitud + "_" + idColaborador + ".pdf";
                JsonDataSource jsd = new JsonDataSource();
                jsd.JsonSource = new CustomJsonSource(json);
                jsd.Fill();
                reportSolicitud.DataSource = jsd;
                reportSolicitud.ExportToPdf(path);
                results = SubirArchivosAzure.getUrlAzure(path);

                SeriLog.GuardarLogApplicacionSerilog("URL SOLICITUD: " + results[0], Enumeraciones.EnumNivelesSeriLog.INFORMATION);

                // System.IO.File.Delete(path);
            }
            catch (Exception ex)
            {
                var message = string.Format(ex.Message);
                throw new Exception(message);
            }
            return results;
        }


        public static List<string> GeneraSolicitudFilePermisos(string fechaSolicitud, string nombresEmpleado, string area, string departamento, string cargo, string CI, string motivo, string fechaHoraDesde, string fechaHoraHasta, string totalHorasDias, string nombreJefe, int idSolicitud, int? idColaborador, int? idTipoAusencia, string observaciones, string empresa)
        {
            List<string> results = new List<string>();
            try
            {
                SolicitudPermiso reportSolicitud = new SolicitudPermiso();

                string path = System.Web.HttpContext.Current.Server.MapPath("~/api/pdf/SolicitudPermisos_") + idSolicitud + "_" + idColaborador + ".pdf";
                Debug.WriteLine("Iniciando generacion de documento.");
                Debug.WriteLine("PATH: " + path);
                string directory = System.IO.Path.GetDirectoryName(path);
                if (!System.IO.Directory.Exists(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }

                reportSolicitud.xrFechaSolicitud.Text = fechaSolicitud ?? string.Empty;
                reportSolicitud.xrNombresEmpleado.Text = nombresEmpleado ?? string.Empty;
                reportSolicitud.xrArea.Text = area ?? string.Empty;
                reportSolicitud.xrDepartamento.Text = departamento ?? string.Empty;
                reportSolicitud.xrCargo.Text = cargo ?? string.Empty;
                reportSolicitud.xrCI.Text = CI ?? string.Empty;
                reportSolicitud.xrMotivo.Text = motivo ?? string.Empty;
                reportSolicitud.xrDesde.Text = fechaHoraDesde ?? string.Empty;
                reportSolicitud.xrHasta.Text = fechaHoraHasta ?? string.Empty;
                reportSolicitud.xrTableTituloTotalHorasDias.Text = (idTipoAusencia == 7 || idTipoAusencia == 2  || idTipoAusencia ==10) ? "Total horas" : "Total días";
                reportSolicitud.xrTotalDiasHoras.Text = totalHorasDias ?? string.Empty;
                reportSolicitud.xrNombreTrabajador.Text = nombresEmpleado ?? string.Empty;
                reportSolicitud.xrNombreJefe.Text = nombreJefe ?? string.Empty;
                reportSolicitud.xrObservaciones.Text = observaciones ?? string.Empty;
                reportSolicitud.xrEmpresa.Text = empresa ?? string.Empty;

                Debug.WriteLine("Exportando a PDF...");
                reportSolicitud.ExportToPdf(path);
                Debug.WriteLine("PDF generado exitosamente en: " + path);

                results = SubirArchivosAzure.getUrlAzure(path);
            }
            catch (DevExpress.XtraReports.DataRetrievalException dex)
            {
                Debug.WriteLine("Error de recuperación de datos DevExpress: " + dex.Message);
                Debug.WriteLine("InnerException: " + (dex.InnerException?.Message ?? "None"));
                throw new Exception("Error al recuperar datos para el reporte: " + dex.Message, dex);
            }
            catch (System.Data.Entity.Core.EntityException eex)
            {
                Debug.WriteLine("Error de Entity Framework: " + eex.Message);
                Debug.WriteLine("InnerException: " + (eex.InnerException?.Message ?? "None"));
                throw new Exception("Error de base de datos: " + eex.Message, eex);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error general: " + ex.Message);
                Debug.WriteLine("InnerException: " + (ex.InnerException?.Message ?? "None"));
                Debug.WriteLine("StackTrace: " + ex.StackTrace);
                throw;
            }
            return results;
        }
        public static List<string> GeneraSolicitudFilePermisosMaternidadPaternidad(string fechaSolicitud, string nombresEmpleado, string area, string departamento, string cargo, string CI, string motivo, string fechaHoraDesde, string fechaHoraHasta, string totalHorasDias, string nombreJefe, int idSolicitud, int? idColaborador, int? idTipoAusencia, string observaciones, string nombreReemplazo)
        {
            List<string> results = new List<string>();
            try
            {
                SolicitudPermisoMaternidadPaternidad reportSolicitud = new SolicitudPermisoMaternidadPaternidad();

                string path = System.Web.HttpContext.Current.Server.MapPath("~/api/pdf/SolicitudPermisos_") + idSolicitud + "_" + idColaborador + ".pdf";
                Debug.WriteLine("Iniciando generacion de documento.");
                Debug.WriteLine("PATH: " + path);
                string directory = System.IO.Path.GetDirectoryName(path);
                if (!System.IO.Directory.Exists(directory))
                {
                    System.IO.Directory.CreateDirectory(directory);
                }

                reportSolicitud.xrFechaSolicitud.Text = fechaSolicitud ?? string.Empty;
                reportSolicitud.xrNombresEmpleado.Text = nombresEmpleado ?? string.Empty;
                reportSolicitud.xrArea.Text = area ?? string.Empty;
                reportSolicitud.xrDepartamento.Text = departamento ?? string.Empty;
                reportSolicitud.xrCargo.Text = cargo ?? string.Empty;
                reportSolicitud.xrCI.Text = CI ?? string.Empty;
                reportSolicitud.xrMotivo.Text = motivo ?? string.Empty;
                reportSolicitud.xrDesde.Text = fechaHoraDesde ?? string.Empty;
                reportSolicitud.xrHasta.Text = fechaHoraHasta ?? string.Empty;
                reportSolicitud.xrTableTituloTotalHorasDias.Text = (idTipoAusencia == 7 || idTipoAusencia == 2 || idTipoAusencia == 8 || idTipoAusencia ==10) ? "Total horas" : "Total días";
                reportSolicitud.xrTotalDiasHoras.Text = totalHorasDias ?? string.Empty;
                reportSolicitud.xrNombreTrabajador.Text = nombresEmpleado ?? string.Empty;
                reportSolicitud.xrNombreJefe.Text = nombreJefe ?? string.Empty;
                reportSolicitud.xrObservaciones.Text = observaciones ?? string.Empty;
                reportSolicitud.xrReemplazo.Text = nombreReemplazo ?? string.Empty;

                Debug.WriteLine("Exportando a PDF...");
                reportSolicitud.ExportToPdf(path);
                Debug.WriteLine("PDF generado exitosamente en: " + path);

                results = SubirArchivosAzure.getUrlAzure(path);
            }
            catch (DevExpress.XtraReports.DataRetrievalException dex)
            {
                Debug.WriteLine("Error de recuperación de datos DevExpress: " + dex.Message);
                Debug.WriteLine("InnerException: " + (dex.InnerException?.Message ?? "None"));
                throw new Exception("Error al recuperar datos para el reporte: " + dex.Message, dex);
            }
            catch (System.Data.Entity.Core.EntityException eex)
            {
                Debug.WriteLine("Error de Entity Framework: " + eex.Message);
                Debug.WriteLine("InnerException: " + (eex.InnerException?.Message ?? "None"));
                throw new Exception("Error de base de datos: " + eex.Message, eex);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error general: " + ex.Message);
                Debug.WriteLine("InnerException: " + (ex.InnerException?.Message ?? "None"));
                Debug.WriteLine("StackTrace: " + ex.StackTrace);
                throw;
            }
            return results;
        }
    }
}