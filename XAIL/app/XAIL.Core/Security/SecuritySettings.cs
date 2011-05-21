using XAIL.ApplicationServices.Configuration;

namespace XAIL.Core.Security
{
    public class SecuritySettings : ISettings
    {
        /// <summary>
        /// Gets or sets an encryption key
        /// </summary>
        public string EncryptionKey { get; set; }
    }
}
