using Config.Net;

namespace Interpreter.Introducer
{
    public interface IConfig
    {
        [Option(DefaultValue = "relay.sightread.xyz")]
        string Host { get; set; }

        [Option(DefaultValue = 55367)]
        int Port { get; set; }

        /// <summary>
        /// Can be a relative or absolute path to a .pfx certificate file.
        /// 
        /// Other formats (.crt, .pem) will not work.
        /// </summary>
        [Option(DefaultValue = "assets\\cert.pfx")]
        string CertificatePath { get; set; }


        /// <summary>
        /// Specifies whether this machine's LAN IP will be sent to the
        /// public Introducer service for peer discovery.
        /// </summary>
        [Option(DefaultValue = true)]
        bool UseIntroducer { get; set; }
    }
}
