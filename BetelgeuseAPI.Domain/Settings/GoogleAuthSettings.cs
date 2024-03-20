using Microsoft.Extensions.Configuration;

namespace BetelgeuseAPI.Domain.Settings
{
    public class GoogleAuthSettings
    {
        [ConfigurationKeyName("ClientId")]
        public string GoogleId { get; set; }
    }
}
