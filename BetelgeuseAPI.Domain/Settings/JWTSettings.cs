using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetelgeuseAPI.Domain.Settings
{
    public class JWTSettings
    {
        public string SecurityKey { get; set; }
        public string Issuer { get; set; }
        public List<String> Audience { get; set; }
        public double AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }

    }
}
