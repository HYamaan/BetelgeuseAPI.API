using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BetelgeuseAPI.Domain.Settings
{
    public class GoogleAuthSettings
    {
        [ConfigurationKeyName("ClientId")]
        public string GoogleId { get; set; }
    }
}
