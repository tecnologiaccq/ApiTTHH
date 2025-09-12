using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Text;
using System.Threading.Tasks;


using Serilog;
using Serilog.Events;
using System.IO;
using System.Configuration;
using static ApiTTHH.Utils.Enumeraciones;


namespace ApiTTHH.Utils
{
	public class SeriLog
	{
		public static void GuardarLogApplicacionSerilog(string mensaje, EnumNivelesSeriLog nivelLog)
		{
			string pathDirectorio = ConfigurationManager.AppSettings.Get("PATH_DIRECTORIO_LOGS_APLICACION");
			DateTime fechaProceso = DateTime.Now;
			string pathArchivo = string.Empty;


			DirectoryInfo dirInfo = new DirectoryInfo(pathDirectorio);
			if (!dirInfo.Exists)
				Directory.CreateDirectory(pathDirectorio);

			pathArchivo = $"{dirInfo.FullName}\\log_.log";

			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.WriteTo.File(pathArchivo, rollingInterval: RollingInterval.Day)
				.CreateLogger();

			try
			{
				switch (nivelLog)
				{
					case EnumNivelesSeriLog.DEBUG:
						Log.Debug(mensaje);
						break;
					case EnumNivelesSeriLog.INFORMATION:
						Log.Information(mensaje);
						break;
					case EnumNivelesSeriLog.WARNING:
						Log.Warning(mensaje);
						break;
					case EnumNivelesSeriLog.ERROR:
						Log.Error(mensaje);
						break;
					case EnumNivelesSeriLog.FATAL:
						Log.Fatal(mensaje);
						break;
					default:
						break;
				}

			}
			catch (Exception ex)
			{
				Log.Fatal(ex, ex.ToString());
			}
			finally
			{
				Log.CloseAndFlush();
			}
		}//end method






	}//end class
}//end namespace