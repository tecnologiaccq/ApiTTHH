                        	
        
using System;
using System.CodeDom.Compiler;

namespace Ccq
{
    /// <summary>
    /// Enumeradores de base de datos, fecha:27/6/2023 21:25:45
    /// </summary>	
    public partial class Enums
    {
                
            #region Proveedor  

            /// <summary>
            /// Proveedor db generated enumeration
            /// </summary>
            [GeneratedCode("TextTemplatingFileGenerator", "10")]
            public enum Proveedor
            {
                                    /// <summary>
                    /// ALPHA TECH Proveedor.
                    /// </summary>			
                                            AlphaTech = 1,

                                        /// <summary>
                    /// TINYURL Proveedor.
                    /// </summary>			
                                            Tinyurl = 2
                    	
        }
     

        #endregion
            
            #region TipoMail  

            /// <summary>
            /// TipoMail db generated enumeration
            /// </summary>
            [GeneratedCode("TextTemplatingFileGenerator", "10")]
            public enum TipoMail
            {
                                    /// <summary>
                    /// Ldp Confirm TipoMail.
                    /// </summary>			
                                            LdpConfirm = 1,

                                        /// <summary>
                    /// Ldp No Confirm TipoMail.
                    /// </summary>			
                                            LdpNoConfirm = 2,

                                        /// <summary>
                    /// Otp Code Ldp TipoMail.
                    /// </summary>			
                                            OtpCodeLdp = 3
                    	
        }
     

        #endregion
            
            #region ConfigKey  

            /// <summary>
            /// ConfigKey db generated enumeration
            /// </summary>
            [GeneratedCode("TextTemplatingFileGenerator", "10")]
            public enum ConfigKey
            {
                                    /// <summary>
                    /// SecretKey ConfigKey.
                    /// </summary>			
                                            Secretkey = 1,

                                        /// <summary>
                    /// MaxDurationYearsLpd ConfigKey.
                    /// </summary>			
                                            Maxdurationyearslpd = 2,

                                        /// <summary>
                    /// BaseUrl ConfigKey.
                    /// </summary>			
                                            Baseurl = 3,

                                        /// <summary>
                    /// PublicKey ConfigKey.
                    /// </summary>			
                                            Publickey = 4,

                                        /// <summary>
                    /// PrivateKey ConfigKey.
                    /// </summary>			
                                            Privatekey = 5,

                                        /// <summary>
                    /// RemoteServerName ConfigKey.
                    /// </summary>			
                                            Remoteservername = 6,

                                        /// <summary>
                    /// IssuerJwt ConfigKey.
                    /// </summary>			
                                            Issuerjwt = 7,

                                        /// <summary>
                    /// AudienceJwt ConfigKey.
                    /// </summary>			
                                            Audiencejwt = 8,

                                        /// <summary>
                    /// KeyJwt ConfigKey.
                    /// </summary>			
                                            Keyjwt = 9,

                                        /// <summary>
                    /// SQLConnect ConfigKey.
                    /// </summary>			
                                            Sqlconnect = 10,

                                        /// <summary>
                    /// InitialCatalogSQL ConfigKey.
                    /// </summary>			
                                            Initialcatalogsql = 11
                    	
        }
     

        #endregion
            
            #region TipoSolicitud  

            /// <summary>
            /// TipoSolicitud db generated enumeration
            /// </summary>
            [GeneratedCode("TextTemplatingFileGenerator", "10")]
            public enum TipoSolicitud
            {
                                    /// <summary>
                    /// Solicitud de Vacaciones Gozadas TipoSolicitud.
                    /// </summary>			
                                            SolicitudDeVacacionesGozadas = 1
                    	
        }
     

        #endregion
    //Fin del for
    }
}

