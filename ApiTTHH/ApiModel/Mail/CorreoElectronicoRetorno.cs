namespace ApiTTHH.ApiModel.Mail
{
    /// <summary>
    /// Modelo Correo Electrónico de Retorno
    /// </summary>
    public class CorreoElectronicoRetorno
    {
        /// <summary>
        /// Código de Error
        /// </summary>
        public string CodigoError { get; set; }

        /// <summary>
        /// ID de Envío
        /// </summary>
        public string IdEnvio { get; set; }

        /// <summary>
        /// Mensaje Proceso
        /// </summary>
        public string MensajeProceso { get; set; }
    }
}